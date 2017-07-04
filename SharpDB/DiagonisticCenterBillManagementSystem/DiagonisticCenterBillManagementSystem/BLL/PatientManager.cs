using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;
using DiagonisticCenterBillManagementSystem.DAL;
using System.Security.Cryptography;
namespace DiagonisticCenterBillManagementSystem.BLL
{
    public class PatientManager:PatientGetway
    {
        PatientGetway patientGetway = new PatientGetway();
        

        public override int AddPatient(Patients patient)
        {
            if (IsBillNoExist(patient.BillNo))
                {
                    throw new Exception("Bill no is already exist");
                }
            
            return base.AddPatient(patient);
        }
      
        public override int GetPatientUpdate(Patients patient)
        {
            return base.GetPatientUpdate(patient);
        }


        public override List<Patients> GetAllPatient()
        {
            return base.GetAllPatient();
        }


        public override List<Payments> GetPatientDetails(string billNo)
        {
            if (IsBillNoExist(billNo))
            {
                return base.GetPatientDetails(billNo);

            }

            throw new Exception("Bill no is not exist");
        }


        public override List<Payments> GetUnPaidBillReport(DateTime fromDate, DateTime toDate)
        {
            return base.GetUnPaidBillReport(fromDate, toDate);
        }


        public override Patients GetPatientByBillNo(string billNo)
        {
            return base.GetPatientByBillNo(billNo);
        }


        // Update bill amount method//
        public string GetPatientUpdateBill(string billNo, decimal PaidBill)
        {
           Patients patient= patientGetway.GetPatientByBillNo(billNo);

            if(patient.TotalFee==patient.PaidBill && PaidBill>patient.TotalFee)
            {
               return "Already Paid";
            }
            else if (patient.TotalFee == PaidBill && PaidBill> patient.PaidBill)
            {
                return patient.PaidBill.ToString();
            }

            else if (PaidBill > patient.TotalFee || PaidBill > patient.PaidBill)
            {
                return "Payment is greater than Bill";
            }
            else if (patient.TotalFee == patient.PaidBill )
            {
                return patient.TotalFee.ToString(); 
            }
            
         
           
            else
            {
              return  (patient.PaidBill).ToString();
            }
        }

        //Due Bill amount method//
        public string GetPatientDueBill(string billNo, decimal PaidBill)
        {
            Patients patient = patientGetway.GetPatientByBillNo(billNo);

         
            if (patient.TotalFee == patient.PaidBill && PaidBill > patient.TotalFee)
            {
                return "0.0000";
            }
            else if (PaidBill > patient.PaidBill && PaidBill > patient.TotalFee)
            {
                return(patient.TotalFee- patient.PaidBill).ToString();
            }
            else if (PaidBill > patient.TotalFee)
            {
                return patient.TotalFee.ToString();
            }
            

            else if ((patient.TotalFee - patient.PaidBill) == 0)
            {
                return "0.0000";
            }
            else if (patient.TotalFee == PaidBill && PaidBill > patient.PaidBill)
            {
                return (patient.TotalFee - patient.PaidBill).ToString();
            }
                else if(patient.TotalFee == PaidBill)
            {
                return "0.0000";
            }
            else
            {
                return  (patient.TotalFee- patient.PaidBill).ToString();
            }
        }
        public bool IsBillNoExist(string billNo)
        {
            bool isBillNoExist = false;
            Patients patient = GetPatientByBillNo(billNo);
            if (patient != null)
            {
                isBillNoExist = true;
            }
            return isBillNoExist;

        }

        //Auto bill no generate method//
        public string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
    }
}