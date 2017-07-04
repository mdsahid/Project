using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    public class Payments
    {
        #region Property
        public string tName { get; set; }
        public decimal testFee { get; set; }
        public string PatientName { get; set; }
        public int MobileNo { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalFee { get; set; }
        public decimal PaidBill { get; set; }
        public decimal UnPaidBill { get; set; }

        #endregion

        #region Constructor
        public Payments() { }
        public Payments(string testName,decimal testFee, string BillNo,DateTime billDate,
            decimal totalFee,decimal paidBill) 
        {
            this.tName = testName;
            this.testFee = testFee;
            this.BillNo = BillNo;
            this.BillDate = billDate;
            this.TotalFee = totalFee;
            this.PaidBill = paidBill;
        
        }

        public Payments(string billNo,int mobileNo,string patientName, decimal unPaidBill)
        {
           
            this.BillNo = billNo;
            this.MobileNo = mobileNo;
            this.PatientName = patientName;
            this.UnPaidBill = unPaidBill;

        }
        #endregion
    }//cs
 #endregion
}//ns