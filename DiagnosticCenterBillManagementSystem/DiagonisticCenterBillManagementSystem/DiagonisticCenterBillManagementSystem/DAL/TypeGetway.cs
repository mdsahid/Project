using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace DiagonisticCenterBillManagementSystem.DAL
{
    #region Class
    public class TypeGetway
    {
        #region Method

        string Connection = WebConfigurationManager.ConnectionStrings["SharpDBConnectionString"].ConnectionString;
       
        // Add Data in TestType table//
        public virtual int AddType(Types testType)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "INSERT INTO TestType VALUES(@typeName)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@typeName", testType.TypeName);
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }


        // Retrieve all Data from TestTable //

        public virtual List<Types> GetAllTestType()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT *FROM TestType";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Types> TypeList = new List<Types>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Id = (int)reader["ID"];
                    string name = reader["typeName"].ToString();
                    Types testType = new Types(name);
                    testType.ID = Id;
                    TypeList.Add(testType);
                }
                reader.Close();
            }
            connection.Close();
            return TypeList;
        }


        // Retrive specific TestType data from TestType table using type name//
        public virtual Types GetTestTypeByName(string Name)
        {
           
            SqlConnection connection = new SqlConnection(Connection);
            string query = "SELECT * FROM TestType WHERE typeName=@typeName";

            connection.Open();
            Types testType = null;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@typeName", Name);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
               reader.Read();
                   string name = reader["TypeName"].ToString();
                   testType = new Types(name);

                   reader.Close();
            }

            connection.Close();
            return testType;
           
        }


     // Type report between specific dates using store procedure//
        public virtual List<TypeReports> GetReportByTypeName(DateTime fromDate, DateTime toDate)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "sp_GetReportByType";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            SqlDataReader reader = command.ExecuteReader();
            List<TypeReports> TestReportList = new List<TypeReports>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string typeName = reader["typeName"].ToString();
                    int totalTest = (int)reader["totalTest"];
                    decimal totalAmount = (decimal)reader["totalAmount"];

                    TypeReports TestReport = new TypeReports(typeName, totalTest, totalAmount);
                    TestReportList.Add(TestReport);
                }
                reader.Close();

            }

            connection.Close();
            return TestReportList;

        }
        #endregion
    }//cs
    #endregion
}//ns