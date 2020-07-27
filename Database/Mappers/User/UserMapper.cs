using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.User;
using System.Data;

namespace Database.Mappers.User
{
    public class UserMapper 
    {

        public int Insert(UserEntity user)
        {
            Database db = new Database();
            db.Connect();
            Dictionary<string, string> transformationMap = user.getTrasformationMap();
            string columns = "(" + String.Join(",", transformationMap.Keys) + ")";
            string values = String.Join(",", transformationMap.Values);
            OracleCommand command = db.CreateCommand(
                "INSERT INTO " + getTableName() + " " + columns + " VALUES ( " + String.Join(",", values) + " ) "
            );
            PrepareCommand(command, user);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(UserEntity user)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET name = :name"
               + " , surname = :surname"
               + " , password = :password"
               + " , date_of_birth = :date_of_birth"
               + " , addresId = :addresId"
               + " , totalPaid = :totalPaid"
               + " , inDebt = :inDebt"
               + " WHERE userId = :userId"
            );
            PrepareCommand(command, user);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<UserEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM \"user\"" 
            );
            OracleDataReader reader = db.Select(command);
            Collection<UserEntity> Users = Read(reader);
            reader.Close();
            db.Close();
            return Users;
        }

        public UserEntity Select(int userId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE userId = :userId"
            );
            command.Parameters.Add(":userId", userId);
            OracleDataReader reader = db.Select(command);
            Collection<UserEntity> Users = Read(reader);
            UserEntity User = null;
            if (Users.Count == 1)
            {
                User = Users[0];
            }
            reader.Close();
            db.Close();
            return User;
        }

        public UserEntity GetByEmailAndPassword(string email, string password)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "SELECT * FROM " + getTableName() + " WHERE email = :email AND password = :password"
            );
            command.Parameters.Add(":email", email);
            command.Parameters.Add(":password", password);
            OracleDataReader reader = db.Select(command);
            Collection<UserEntity> Users = Read(reader);
            UserEntity User = null;
            if (Users.Count == 1)
            {
                User = Users[0];
            }
            reader.Close();
            db.Close();
            return User;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            /*
             * DODELAT TRIGGER smszani vsech user_course
            */
            OracleCommand command = db.CreateCommand(
                "DELETE FROM " + getTableName() + " WHERE userId = :userId"
            );

            command.Parameters.Add(":userId", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, UserEntity User)
        {
            command.BindByName = true;
            command.Parameters.Add(":userId", User.userId);
            command.Parameters.Add(":name", User.name);
            command.Parameters.Add(":surname", User.surname);
            command.Parameters.Add(":password", User.password);
            command.Parameters.Add(":date_of_birth", User.date_of_birth);
            command.Parameters.Add(":addresId", User.addresId);
            command.Parameters.Add(":totalPaid", User.totalPaid);
            command.Parameters.Add(":inDebt", User.inDebt);
        }

        private string getTableName()
        {
            return "\"user\"";
        }

        private static Collection<UserEntity> Read(OracleDataReader reader)
        {
            Collection<UserEntity> Users = new Collection<UserEntity>();
            while (reader.Read())
            {
                int i = -1;
                UserEntity User = new UserEntity();
                User.userId = reader.GetInt32(++i);
                User.name = reader.GetString(++i);
                User.surname = reader.GetString(++i);
                User.email = reader.GetString(++i);
                User.password = reader.GetString(++i);
                User.date_of_birth = reader.GetDateTime(++i);
                User.addresId = reader.GetInt32(++i);
                User.totalPaid = reader.GetFloat(++i);
                User.inDebt = reader.GetInt32(++i) == 1;
                Users.Add(User);
            }
            return Users;
        }

        public void SetDebts()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand commandDebt = new OracleCommand(
                  "SetUserInDebt",
                  db.Connection
            );
            commandDebt.CommandType = CommandType.StoredProcedure;
            db.ExecuteNonQuery(commandDebt);
        }

    }
}
