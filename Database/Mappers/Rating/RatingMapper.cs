using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database.Entities.Rating;
using System.Data;

namespace Database.Mappers.Rating
{
    public class RatingMapper
    {
        public int Insert(RatingEntity entity)
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

        public int Update(RatingEntity entity, int teacherId, int userId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
               "UPDATE " + getTableName()
               + " SET points = :points"
               + " WHERE teacherId = :teacherId"
               + " AND userId = :userId"
            );
            command.Parameters.Add(":userId", userId);
            command.Parameters.Add(":teacherId", teacherId);
            PrepareCommand(command, entity);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<RatingEntity> Select()
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "SELECT * FROM " + getTableName()
            );
            OracleDataReader reader = db.Select(command);
            Collection<RatingEntity> Entities = Read(reader);
            reader.Close();
            db.Close();
            return Entities;
        }

        public int Delete(int teacherId, int userId)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(
                "DELETE FROM " + getTableName()
                + " WHERE teacherId = :teacherId"
                + " AND userId = :userId"
            );
            command.Parameters.Add(":userId", userId);
            command.Parameters.Add(":teacherId", teacherId);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, RatingEntity entity)
        {
            command.BindByName = true;
            command.Parameters.Add(":userId", entity.userId);
            command.Parameters.Add(":teacherId", entity.teacherId);
            command.Parameters.Add(":points", entity.points);
        }

        private string getTableName()
        {
            return "Rating";
        }

        public void CalculateAverage(int teacherId)
        {
            Database db = new Database();
            db.Connect();
            Console.WriteLine("CalculateAverageRating");
            OracleCommand commandAverageRating = new OracleCommand(
                 "CalculateAverageRating",
                 db.Connection
            );
            commandAverageRating.CommandType = CommandType.StoredProcedure;
            commandAverageRating.Parameters.Add("p_teacherId", OracleDbType.Int32).Value = teacherId;
            db.ExecuteNonQuery(commandAverageRating);
        }

        private static Collection<RatingEntity> Read(OracleDataReader reader)
        {
            Collection<RatingEntity> Teachers = new Collection<RatingEntity>();
            while (reader.Read())
            {
                int i = -1;
                RatingEntity Teacher = new RatingEntity();
                Teacher.userId = reader.GetInt32(++i);
                Teacher.teacherId = reader.GetInt32(++i);
                Teacher.points = reader.GetInt32(++i);
                Teachers.Add(Teacher);
            }
            return Teachers;
        }
    }
}
