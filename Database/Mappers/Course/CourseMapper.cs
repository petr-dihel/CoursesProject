using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Course;
using System.Data;

namespace Database.Mappers.Course
{
    public class CourseMapper
    {
        public int Insert(CourseEntity entity)
        {
            Database db = new Database();
            db.Connect();
            Dictionary<string, string> transformationMap = entity.getTrasformationMap();
            string columns = "(" + String.Join(",", transformationMap.Keys) + ")";
            string values = String.Join(",", transformationMap.Values);
            OracleCommand command = db.CreateCommand(
               "INSERT INTO Course(courseId, \"date\", duration, subject, minRequiredPoints, price, teacherId) "
               + " VALUES(null, to_date(:d_date, 'mm/dd/yyyy'), :duration, :subject, :minRequiredPoints, :price, :teacherId)"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(CourseEntity entity)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET \"date\" = :d_date"
               + " , duration = :duration"
               + " , subject = :subject"
               + " , minRequiredPoints = :minRequiredPoints"
               + " , price = :price"
               + " , teacherId = :teacherId"
               + " WHERE courseId = :courseId"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<CourseEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<CourseEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public CourseEntity Select(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE courseId = :courseId"
            );
            command.Parameters.Add(":courseId", entityId);
            OracleDataReader reader = db.Select(command);
            Collection<CourseEntity> Entities = Read(reader);
            CourseEntity Entity = null;
            if (Entities.Count == 1)
            {
                Entity = Entities[0];
            }
            reader.Close();
            db.Close();
            return Entity;
        }

        public int Delete(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "DELETE FROM " + getTableName() + " WHERE courseId = :courseId"
            );

            command.Parameters.Add(":courseId", entityId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public Collection<CourseEntity> getBysubject(string searchTerm)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
                + " WHERE subject = :subject"
            );
            command.Parameters.Add(":subject", searchTerm);
            OracleDataReader reader = db.Select(command);
            Collection<CourseEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public void InsertIntoUserCourse(string userId, string courseId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "INSERT INTO userCourse (userId,courseId)"
                + " VALUES(:userId, :courseId)"
            );
            command.Parameters.Add(":userId", Int32.Parse(userId));
            command.Parameters.Add(":courseId", Int32.Parse(courseId));
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<CourseEntity> getUserCourse(int userId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
                + " JOIN userCourse ON course.courseId = userCourse.courseId"
                + " WHERE userCourse.userId = :userId"
            );
            command.Parameters.Add(":userId", userId);
            OracleDataReader reader = db.Select(command);
            Collection<CourseEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        private void PrepareCommand(OracleCommand command, CourseEntity Entity)
        {
            command.BindByName = true;
            DateTime dateTime = DateTime.Parse(Entity.date);
            OracleParameter tmp = new OracleParameter(":d_date", OracleDbType.Date, dateTime, ParameterDirection.Input);       
            command.Parameters.Add(tmp);
            command.Parameters.Add(":duration", Entity.duration);
            command.Parameters.Add(":subject", Entity.subject);
            command.Parameters.Add(":minRequiredPoints", Entity.minRequiredPoints);
            command.Parameters.Add(":price", Entity.price);
            command.Parameters.Add(":teacherId", Entity.teacherId);
        }

        private string getTableName()
        {
            return "Course";
        }

        private static Collection<CourseEntity> Read(OracleDataReader reader)
        {
            Collection<CourseEntity> Entities = new Collection<CourseEntity>();
            while (reader.Read())
            {
                int i = -1;
                CourseEntity Entity = new CourseEntity();
                Entity.courseId = reader.GetInt32(++i);
                Entity.date = reader.GetDateTime(++i).ToString();
                Entity.duration = reader.GetInt32(++i);
                Entity.subject = reader.GetString(++i);
                Entity.minRequiredPoints = reader.GetInt32(++i);
                Entity.price = reader.GetFloat(++i);
                Entity.teacherId = reader.GetInt32(++i);
                Entities.Add(Entity);
            }
            return Entities;
        }

        public bool isSignedToCourse(int courseId, int userId)
        {

            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT userId "
                + " FROM userCourse"
                + " WHERE userCourse.userId = :userId"
                + " AND userCourse.courseId = :courseId"
            );
            command.Parameters.Add(":userId", userId);
            command.Parameters.Add(":courseId", courseId);
            OracleDataReader reader = db.Select(command);
            int res = -1;
            while (reader.Read())
            {
                res = reader.GetInt32(0);
            }
            reader.Close();
            db.Close();
            return res > 0;
        }
    }
}
