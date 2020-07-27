using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Administrator;

namespace Database.Mappers.Administrator
{
    public class AdministratorMapper
    {
        public int Insert(AdministratorEntity entity)
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

        public int Update(AdministratorEntity entity)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET password = :password"
               + " SET email = :email"
               + " WHERE administratorId = :administratorId"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<AdministratorEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<AdministratorEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public AdministratorEntity Select(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE administratorId = :administratorId"
            );
            command.Parameters.Add(":administratorId", entityId);
            OracleDataReader reader = db.Select(command);
            Collection<AdministratorEntity> Entities = Read(reader);
            AdministratorEntity Entity = null;
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
                "DELETE FROM " + getTableName() + " WHERE administratorId = :administratorId"
            );

            command.Parameters.Add(":administratorId", entityId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, AdministratorEntity Entity)
        {
            command.BindByName = true;
            command.Parameters.Add(":administratorId", Entity.administratorId);
            command.Parameters.Add(":password", Entity.password);
            command.Parameters.Add(":email", Entity.email);
        }

        private string getTableName()
        {
            return "Administrator";
        }

        private static Collection<AdministratorEntity> Read(OracleDataReader reader)
        {
            Collection<AdministratorEntity> Entities = new Collection<AdministratorEntity>();
            while (reader.Read())
            {
                int i = -1;
                AdministratorEntity Entity = new AdministratorEntity();
                Entity.administratorId = reader.GetInt32(++i);
                Entity.password = reader.GetString(++i);
                Entity.email = reader.GetString(++i);
                Entities.Add(Entity);
            }
            return Entities;
        }

        public AdministratorEntity GetByEmailAndPassword(string email, string password)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "SELECT * FROM " + getTableName() + " WHERE email = :email AND password = :password"
            );
            command.Parameters.Add(":email", email);
            command.Parameters.Add(":password", password);
            OracleDataReader reader = db.Select(command);
            Collection<AdministratorEntity> administrators = Read(reader);
            AdministratorEntity adminstrator = null;
            if (administrators.Count == 1)
            {
                adminstrator = administrators[0];
            }
            reader.Close();
            db.Close();
            return adminstrator;
        }

    }
}
