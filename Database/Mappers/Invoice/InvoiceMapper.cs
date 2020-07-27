using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Invoice;

namespace Database.Mappers.Invoice
{
    public class InvoiceMapper
    {
        public int Insert(InvoiceEntity entity)
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

        public int Update(InvoiceEntity entity)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET password = :password"
               + " , paid = :paid"
               + " , dateCreated = :dateCreated"
               + " , dueDate = :dueDate"
               + " WHERE invoiceId = :invoiceId"
            );
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<InvoiceEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<InvoiceEntity> Teachers = Read(reader);
            reader.Close();
            db.Close();
            return Teachers;
        }

        public InvoiceEntity Select(int entityId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName() + " WHERE userId = :userId"
            );
            command.Parameters.Add(":invoiceId", entityId);
            OracleDataReader reader = db.Select(command);
            Collection<InvoiceEntity> Entities = Read(reader);
            InvoiceEntity Entity = null;
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
                "DELETE FROM " + getTableName() + " WHERE invoiceId = :invoiceId"
            );

            command.Parameters.Add(":invoiceId", entityId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, InvoiceEntity Entity)
        {
            command.BindByName = true;
            command.Parameters.Add(":invoiceId", Entity.invoiceId);
            command.Parameters.Add(":paid", Entity.paid);
            command.Parameters.Add(":dateCreated", Entity.dateCreated);
            command.Parameters.Add(":dueDate", Entity.dueDate);
        }

        private string getTableName()
        {
            return "Invoice";
        }

        private static Collection<InvoiceEntity> Read(OracleDataReader reader)
        {
            Collection<InvoiceEntity> Entities = new Collection<InvoiceEntity>();
            while (reader.Read())
            {
                int i = -1;
                InvoiceEntity Entity = new InvoiceEntity();
                Entity.invoiceId = reader.GetInt32(++i);
                Entity.paid = reader.GetInt32(++i) == 1;
                Entity.dateCreated = reader.GetDateTime(++i).ToString();
                Entity.dueDate = reader.GetDateTime(++i).ToString();
                Entities.Add(Entity);
            }
            return Entities;
        }

        public Collection<InvoiceEntity> getUsersInvoices(int userId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT Invoice.* FROM " + getTableName()
                + " JOIN userCourse ON Invoice.invoiceId = userCourse.invoiceId"
                + " WHERE userCourse.userId = :userId"
            );
            command.Parameters.Add(":userId", userId);
            OracleDataReader reader = db.Select(command);
            Collection<InvoiceEntity> Invoices = Read(reader);
            reader.Close();
            db.Close();
            return Invoices;
        }

        public float getPrice(int invoiceId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT Price FROM " + getTableName()
                + " JOIN userCourse ON Invoice.invoiceId = userCourse.invoiceId"
                + " JOIN Course ON userCourse.courseID = Course.courseId"
                + " WHERE userCourse.invoiceId = :invoiceId"
            );
            command.Parameters.Add(":invoiceId", invoiceId);
            OracleDataReader reader = db.Select(command);
            Collection<InvoiceEntity> Entities = new Collection<InvoiceEntity>();
            float price = 0;
            while (reader.Read())
            {
                int i = -1;
                price = reader.GetFloat(++i);
            }
            reader.Close();
            db.Close();
            return price;
        }

    }
}
