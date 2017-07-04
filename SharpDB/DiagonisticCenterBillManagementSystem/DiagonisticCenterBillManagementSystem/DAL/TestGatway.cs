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
    public class TestGatway
    {
        #region Method
        Types testType = new Types();
        string Connection = WebConfigurationManager.ConnectionStrings["SharpDBConnectionString"].ConnectionString;
        
        //Add data in TestSetup table//
        public virtual int AddTest(Tests test)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "INSERT INTO TestSetup VALUES(@testName,@testFee,@typeID)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testName", test.tName);
            command.Parameters.AddWithValue("@testFee", test.testFee);
            command.Parameters.AddWithValue("@typeID", test.typeID);
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        //Retrieve  all tests from Testsetup table//
        public virtual List<Tests> GetAllTest()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT * from TestSetup";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Tests> TestList = new List<Tests>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader["testName"].ToString();
                    decimal Fee = (decimal)reader["testFee"];
                    int type = (int)reader["typeID"];
                    Tests testName = new Tests(name, Fee, type);
                    testName.ID =(int) reader["ID"];
                    TestList.Add(testName);
                }
                reader.Close();
            }
            connection.Close();
            return TestList;
        }

        //Retrieve all test details( included type name) using view // 
        public virtual List<TestDetails> GetAllTestWithType()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT * FROM  VW_TestDetails";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<TestDetails> TestList = new List<TestDetails>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader["Test"].ToString();
                    decimal Fee = (decimal)reader["Fee"];
                    string type = reader["Type"].ToString();
                    TestDetails test = new TestDetails(name, Fee, type);

                    TestList.Add(test);
                }
                reader.Close();
            }
            connection.Close();
            return TestList;
        }


        //Retrieve specific test data from TestSetup table using test name//
        public virtual Tests GetTestByName(string Name)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "SELECT * FROM TestSetup WHERE testName=@testName";

            connection.Open();
            Tests test = null;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testName", Name);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string name = reader["testName"].ToString();
                decimal testFee = (decimal)reader["testFee"];
                int typeId = (int)reader["typeID"];
                test = new Tests(name,testFee,typeId);

                reader.Close();
            }

            connection.Close();
            return test;

        }


        //Test report between specific dates using store procedure//
        public virtual List<TestReports> GetReportByTestName(DateTime fromDate, DateTime toDate)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "sp_GetReportByTest";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            SqlDataReader reader = command.ExecuteReader();
            List<TestReports> TestReportList = new List<TestReports>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string testName = reader["testName"].ToString();
                    int totalTest = (int)reader["totalTest"];
                    decimal totalAmount = (decimal)reader["totalAmount"];

                    TestReports TestReport = new TestReports(testName,totalTest,totalAmount);
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