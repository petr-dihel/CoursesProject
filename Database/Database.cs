using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    public class Database
    {
        public OracleConnection Connection { get; set; }
        private OracleTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new OracleConnection();
            Language = "en";
        }

        public bool Connect()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = Properties.Settings.Default.OracleConnection;
                Connection.Open();
            }
            return true;
        }

        public bool Connect(String conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            // command.Dispose()
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(OracleCommand command)
        {
            int rowNumber = 0;
            try
            {
                BeginTransaction();
                rowNumber = command.ExecuteNonQuery();
                EndTransaction();            }
            catch (Exception e)
            {
                Rollback();
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }

        public OracleCommand CreateCommand(string strCommand)
        {
            OracleCommand command = new OracleCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public OracleDataReader Select(OracleCommand command)
        {
            command.Prepare();
            OracleDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

    }
}
