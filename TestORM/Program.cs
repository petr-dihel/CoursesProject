using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using Database;
using Database.Mappers.User;
using Database.Entities.User;

namespace TestORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.Database db = new Database.Database();
           
            bool connected = db.Connect(Properties.Settings.Default.OracleConnection);
            UserMapper userMapper = new UserMapper();
            Collection<UserEntity> users = userMapper.Select();
            Console.WriteLine("Test of UserEntity: ");
            foreach (UserEntity item in users) {
                Console.WriteLine("UserId: " + item.userId + " totalPaid: " + item.totalPaid);
                OracleCommand commandtmp = new OracleCommand(
                  "CountTotalPaidInvoices",
                  db.Connection
                );
                commandtmp.CommandType = CommandType.StoredProcedure;
                commandtmp.Parameters.Add("p_userId", OracleDbType.Int32).Value = item.userId;
                commandtmp.ExecuteNonQuery();
            }
          
            Console.WriteLine("After CountTotalPaidInvoices : ");

            Collection <UserEntity> users2 = userMapper.Select();
            foreach (UserEntity item in users2)
            {
                Console.WriteLine("UserId: " + item.userId + " totalPaid: " + item.totalPaid);
            }

            db.Connect();
            Console.WriteLine("Set debts");
            OracleCommand commandDebt = new OracleCommand(
                  "SetUserInDebt",
                  db.Connection
            );
            commandDebt.CommandType = CommandType.StoredProcedure;
            db.ExecuteNonQuery(commandDebt);

            db.Connect();
            Console.WriteLine("CalculateAverageRating");
            OracleCommand commandAverageRating = new OracleCommand(
                 "CalculateAverageRating",
                 db.Connection
            );
            commandAverageRating.CommandType = CommandType.StoredProcedure;
            commandAverageRating.Parameters.Add("p_teacherId", OracleDbType.Int32).Value = 1;
            db.ExecuteNonQuery(commandAverageRating);

            /* hlasi blbe vstupni argumenty*/
            DataSet dataset = new DataSet();
            db.Connect();
            Console.WriteLine("teacherList");
            OracleCommand commandTeacherList = new OracleCommand(
                 "teacherList",
                 db.Connection
            );
            commandTeacherList.CommandType = CommandType.StoredProcedure;
            OracleParameter returnParam = new OracleParameter("teachers", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            commandTeacherList.Parameters.Add(returnParam);
            commandTeacherList.Parameters.Add("p_teacherId", OracleDbType.Int32).Value = 1;
            commandTeacherList.Parameters.Add("p_orderBy", OracleDbType.Varchar2).Value = "surname";
            commandTeacherList.Parameters.Add("p_order", OracleDbType.Varchar2).Value = "desc";
      
            db.ExecuteNonQuery(commandTeacherList);
            OracleDataAdapter da = new OracleDataAdapter(commandTeacherList);
            da.Fill(dataset);
       
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                foreach (DataColumn columns in dataset.Tables[0].Columns) {
                    Console.WriteLine(columns + " : " + row[columns]);
                }         
            }

            //Console.WriteLine(dataset.GetXml());
            //Console.WriteLine(dataset.ToString());
            //Console.WriteLine(dataset.ToString());
  
            DateTime tmp = DateTime.Today;
            db.Connect();
            Console.WriteLine("InsertCertificate");
            OracleCommand commandInsertCertificate = new OracleCommand(
                 "InsertCertificate",
                 db.Connection
            );
            commandInsertCertificate.CommandType = CommandType.StoredProcedure;
            commandInsertCertificate.Parameters.Add("p_courseId", OracleDbType.Int32).Value = 1;
            commandInsertCertificate.Parameters.Add("p_teacherId", OracleDbType.Date).Value = tmp;
            db.ExecuteNonQuery(commandInsertCertificate);
            Console.WriteLine("Done all");
            db.Close();
            Console.ReadLine();
        }
    }
}
