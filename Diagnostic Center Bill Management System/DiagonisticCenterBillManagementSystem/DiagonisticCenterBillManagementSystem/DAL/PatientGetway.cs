using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;
using System.Web.Configuration;
using System.Data.SqlClient;
namespace DiagonisticCenterBillManagementSystem.DAL
{
    #region Class
    public class PatientGetway
    {

        #region Method

       string Connection = WebConfigurationManager.ConnectionStrings["SharpDBConnectionString"].ConnectionString;
       
        
        //Add Patient info in Patient table//
        public virtual int AddPatient(Patients patient)
        {
            SqlConnection connection = new SqlConnection(Connection);

            string query = "Insert into Patient values(@patientName,@DateOfBirth,@MobileNO,@BillNo,@BillDate,@TotalFee,@PaidBill)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@patientName", patient.patientName);
            command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            command.Parameters.AddWithValue("@MobileNO", patient.MobileNO);
            command.Parameters.AddWithValue("@BillNo", patient.BillNo);
            command.Parameters.AddWithValue("@BillDate", patient.BillDate);
            command.Parameters.AddWithValue("@TotalFee", patient.TotalFee);
            command.Parameters.AddWithValue("@PaidBill", patient.PaidBill);
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        //Retrieve all patients info from Patient table//
        public virtual List<Patients> GetAllPatient()
        {

            SqlConnection connection = new SqlConnection(Connection);

            string query = "SELECT *FROM Patient";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Patients> patientList = new List<Patients>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader["patientName"].ToString();
                    DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                    int mobileNo = (int)reader["MobileNO"];
                    string billNo = reader["BillNo"].ToString();
                    DateTime billDate = (DateTime)reader["BillDate"];
                    decimal totalFee = (decimal)reader["TotalFee"];
                    decimal PaidBill = (decimal)reader["PaidBill"];

                    Patients patient = new Patients(name, dateOfBirth, mobileNo, billNo, billDate, totalFee, PaidBill);
                    patient.ID = (int)reader["ID"];
                    patientList.Add(patient);
                }
                reader.Close();
            }
            connection.Close();
            return patientList;
        }


        //Retrieve specific patient info using  bill no from patient table//  
        public virtual Patients GetPatientByBillNo(string billNo)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "SELECT * FROM Patient WHERE BillNo=@billNo";

            connection.Open();
            Patients patient = null;
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@billNo", billNo);
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string name = reader["patientName"].ToString();
                DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                int mobileNo = (int)reader["MobileNO"];
                string BillNo = reader["BillNo"].ToString();
                DateTime billDate = (DateTime)reader["BillDate"];
                decimal totalFee = (decimal)reader["TotalFee"];
                decimal PaidBill = (decimal)reader["PaidBill"];
                patient = new Patients(name, dateOfBirth, mobileNo, billNo, billDate, totalFee, PaidBill);

                reader.Close();
            }

            connection.Close();
            return patient;

        }

        //retrieve patient details(patient info & requested tests) with a store procedure//
        public virtual List<Payments> GetPatientDetails(string billNo)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "SP_PatientPaymentByBillNo";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@billNo", billNo);
            SqlDataReader reader = command.ExecuteReader();
            List<Payments> patientDetailsList = new List<Payments>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader["testName"].ToString();
                    decimal testFee = (decimal)reader["testFee"];
                    string BillNo = reader["BillNo"].ToString();
                    DateTime billDate = (DateTime)reader["BillDate"];
                    decimal totalFee = (decimal)reader["TotalFee"];
                    decimal PaidBill = (decimal)reader["PaidBill"];
                    Payments patientDetails= new Payments(name, testFee, BillNo, billDate, totalFee, PaidBill);
                    patientDetailsList.Add(patientDetails);
                }
                reader.Close();

            }

            connection.Close();
            return patientDetailsList;

        }

        // Updating patient info in Patient table using store procedure//
        public virtual  int GetPatientUpdate(Patients patient)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "Sp_PatientDetailsUpdate";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PaidBill", patient.PaidBill);
            command.Parameters.AddWithValue("@billNo", patient.BillNo);
        
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;

           

        }

        //Unpaid bill report between specific dates using store procedure//
        public virtual List<Payments> GetUnPaidBillReport(DateTime fromDate, DateTime toDate)
        {

            SqlConnection connection = new SqlConnection(Connection);
            string query = "sp_UnPaidBillReport";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            SqlDataReader reader = command.ExecuteReader();
            List<Payments> UnPaidBillReportList = new List<Payments>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string billNo = reader["BillNo"].ToString();
                    int mobileNo = (int)reader["MobileNo"];
                    string patientName = reader["PatientName"].ToString();
                    decimal unPaidBill = (decimal)reader["UnPaidBill"];

                    Payments paymentViewModel = new Payments(billNo, mobileNo, patientName, unPaidBill);
                    UnPaidBillReportList.Add(paymentViewModel);
                }
                reader.Close();

            }

            connection.Close();
            return UnPaidBillReportList;

        }
         #endregion
    }//cs
    #endregion
}//ns