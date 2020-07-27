using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Certificate;
using System.Data;

namespace Database.Mappers.Certificate
{
    public class CertificateMapper
    {
        public int Insert(CertificateEntity entity)
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

        public int Update(CertificateEntity entity)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET expirationDate = :expirationDate"
               + " WHERE certificateId = :certificateId"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<CertificateEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<CertificateEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public CertificateEntity Select(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE certificateId = :certificateId"
            );
            command.Parameters.Add(":certificateId", entityId);
            OracleDataReader reader = db.Select(command);
            Collection<CertificateEntity> Entities = Read(reader);
            CertificateEntity Entity = null;
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
                "DELETE FROM " + getTableName() + " WHERE certificateId = :certificateId"
            );

            command.Parameters.Add(":certificateId", entityId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, CertificateEntity Entity)
        {
            command.BindByName = true;
            command.Parameters.Add(":certificateId", Entity.certificateId);
            command.Parameters.Add(":expirationDate", Entity.expirationDate);
        }

        private string getTableName()
        {
            return "Certificate";
        }

        private static Collection<CertificateEntity> Read(OracleDataReader reader)
        {
            Collection<CertificateEntity> Entities = new Collection<CertificateEntity>();
            while (reader.Read())
            {
                int i = -1;
                CertificateEntity Entity = new CertificateEntity();
                Entity.certificateId = reader.GetInt32(++i);
                Entity.expirationDate = reader.GetString(++i);
                Entities.Add(Entity);
            }
            return Entities;
        }

        public void InsertCertificates(int courseId, int teacherId)
        {
            Database db = new Database();
            db.Connect();
            Console.WriteLine("InsertCertificate");
            OracleCommand commandInsertCertificate = new OracleCommand(
                 "InsertCertificate",
                 db.Connection
            );
            commandInsertCertificate.CommandType = CommandType.StoredProcedure;
            commandInsertCertificate.Parameters.Add("p_courseId", OracleDbType.Int32).Value = courseId;
            commandInsertCertificate.Parameters.Add("p_teacherId", OracleDbType.Date).Value = teacherId;
            db.ExecuteNonQuery(commandInsertCertificate);
        }
    
    }
}
