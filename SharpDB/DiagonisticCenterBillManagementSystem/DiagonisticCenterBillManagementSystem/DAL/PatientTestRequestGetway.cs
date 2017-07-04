using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagonisticCenterBillManagementSystem.Models;

namespace DiagonisticCenterBillManagementSystem.DAL
{
    #region Class
    public class PatientTestRequestGetway
    {
        #region Method
       
        
        
        string Connection = WebConfigurationManager.ConnectionStrings["SharpDBConnectionString"].ConnectionString;


        // Add data in PatientRequestTest table//
        public virtual int AddTestRequest(PatientTestRequest testRequest)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "INSERT INTO [PatientRequestTest] VALUES(@PatientID,@TestID)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", testRequest.patientID);
            command.Parameters.AddWithValue("@TestID", testRequest.TestID);
          
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }
        //Retrieve all data from PatientRequestTest table//
        public virtual List<PatientTestRequest> GetAllTestRequest()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT *FROM [PatientRequestTest]";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<PatientTestRequest> TestRequestList = new List<PatientTestRequest>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int patientId = (int)reader["PatientID"];
                    int testID = (int)reader["TestID"];
                    PatientTestRequest TestRequest = new PatientTestRequest(patientId, testID);

                    TestRequestList.Add(TestRequest);
                }
                reader.Close();
            }
            connection.Close();
            return TestRequestList;
        }
        #endregion
    }//cs
        #endregion
}//ns