using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    public class TestReports
    {
        #region Property
        public string TestName { get; set; }
        public int TotalTest { get; set; }

        public decimal TotalAmount { get; set; }

        #endregion
        #region Constructor
        public TestReports() { }

        public TestReports(string testName, int totalTest, decimal totalAmount)
        {
            this.TestName = testName;
            this.TotalTest = totalTest;
            this.TotalAmount = totalAmount;
        }
        #endregion
    }//cs
    #endregion
}//ns