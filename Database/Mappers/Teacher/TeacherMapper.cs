using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Teacher;

namespace Database.Mappers.Teacher
{
    public class TeacherMapper
    {

        public int Insert(TeacherEntity entity)
        {
            Database db = new Database();
            db.Connect();
            Dictionary<string, string> transformationMap = entity.getTrasformationMap();
            string columns = "(" + String.Join(",", transformationMap.Keys) + ")";
            string values = String.Join(",", transformationMap.Values);
            OracleCommand command = db.CreateCommand(
                "INSERT INTO " + getTableName() + " " + columns + " VALUES ( " + String.Join(",", values) + " ) "
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(TeacherEntity teacher)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET password = :password"
               + " , name = :name"
               + " , surname = :surname"
               + " , telephone = :telephone"
               + " , date_of_birth = :date_of_birth"
               + " , email = :email"
               + " , averageRating = :averageRating"
               + " WHERE teacherId = :teacherId"
            );
            PrepareCommand(command, teacher);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<TeacherEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<TeacherEntity> Teachers = Read(reader);
            reader.Close();
            db.Close();
            return Teachers;
        }

        public TeacherEntity Select(int teacherId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE teacherId = :teacherId"
            );
            command.Parameters.Add(":teacherId", teacherId);
            OracleDataReader reader = db.Select(command);
            Collection<TeacherEntity> Teachers = Read(reader);
            TeacherEntity Teacher = null;
            if (Teachers.Count == 1)
            {
                Teacher = Teachers[0];
            }
            reader.Close();
            db.Close();
            return Teacher;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "DELETE FROM " + getTableName() + " WHERE teacherId = :teacherId"
            );

            command.Parameters.Add(":teacherId", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, TeacherEntity Teacher)
        {
            command.BindByName = true;
            command.Parameters.Add(":teacherId", Teacher.teacherId);
            command.Parameters.Add(":password", Teacher.password);
            command.Parameters.Add(":name", Teacher.name);
            command.Parameters.Add(":surname", Teacher.surname);
            command.Parameters.Add(":telephone", Teacher.telephone);
            command.Parameters.Add(":date_of_birth", Teacher.date_of_birth);
            command.Parameters.Add(":email", Teacher.email);
            command.Parameters.Add(":averageRating", Teacher.averageRating);
        }

        private string getTableName()
        {
            return "Teacher";
        }

        private static Collection<TeacherEntity> Read(OracleDataReader reader)
        {
            Collection<TeacherEntity> Teachers = new Collection<TeacherEntity>();
            while (reader.Read())
            {
                int i = -1;
                TeacherEntity Teacher = new TeacherEntity();
                Teacher.teacherId = reader.GetInt32(++i);
                Teacher.password = reader.GetString(++i);
                Teacher.name = reader.GetString(++i);
                Teacher.surname = reader.GetString(++i);
                Teacher.telephone = reader.GetString(++i);
                Teacher.date_of_birth = reader.GetDateTime(++i);
                Teacher.email = reader.GetString(++i);
                Teacher.averageRating = reader.GetFloat(++i);
                Teachers.Add(Teacher);
            }
            return Teachers;
        }

        public TeacherEntity GetByEmailAndPassword(string email, string password)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "SELECT * FROM " + getTableName() + " WHERE email = :email AND password = :password"
            );
            command.Parameters.Add(":email", email);
            command.Parameters.Add(":password", password);
            OracleDataReader reader = db.Select(command);
            Collection<TeacherEntity> teachers = Read(reader);
            TeacherEntity teacher = null;
            if (teachers.Count == 1)
            {
                teacher = teachers[0];
            }
            reader.Close();
            db.Close();
            return teacher;
        }

    }
}
