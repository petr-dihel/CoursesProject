using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Address;

namespace Database.Mappers.Address
{
    public class AddressMapper
    {
        public int Insert(AddressEntity entity)
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
            OracleCommand commandLastId = db.CreateCommand(
                "SELECT MAX(addressId) " + getTableName() 
            );
            OracleDataReader reader = db.Select(command);
            int lastId = reader.GetInt32(0);
            db.Close();
            return lastId;
        }

        public int Update(AddressEntity entity)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET city = :city, "
               + " postCode = :postCode "
               + " street = :street "
               + " state = :state "
               + " WHERE addressId = :addressId"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<AddressEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<AddressEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public AddressEntity Select(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE addressId = :addressId"
            );
            command.Parameters.Add(":addressId", entityId);
            OracleDataReader reader = db.Select(command);
            Collection<AddressEntity> Entities = Read(reader);
            AddressEntity Entity = null;
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
                "DELETE FROM " + getTableName() + " WHERE addressId = :addressId"
            );

            command.Parameters.Add(":addressId", entityId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, AddressEntity Entity)
        {
            command.BindByName = true;
            command.Parameters.Add(":addressId", Entity.addressId);
            command.Parameters.Add(":city", Entity.city);
            command.Parameters.Add(":postCode", Entity.postCode);
            command.Parameters.Add(":street", Entity.street);
            command.Parameters.Add(":state", Entity.state);
        }

        private string getTableName()
        {
            return "Address";
        }

        private static Collection<AddressEntity> Read(OracleDataReader reader)
        {
            Collection<AddressEntity> Entities = new Collection<AddressEntity>();
            while (reader.Read())
            {
                int i = -1;
                AddressEntity Entity = new AddressEntity();
                Entity.addressId = reader.GetInt32(++i);
                Entity.city = reader.GetString(++i);
                Entity.postCode = reader.GetString(++i);
                Entity.street = reader.GetString(++i);
                Entity.state = reader.GetString(++i);
                Entities.Add(Entity);
            }
            return Entities;
        }
    }
}
