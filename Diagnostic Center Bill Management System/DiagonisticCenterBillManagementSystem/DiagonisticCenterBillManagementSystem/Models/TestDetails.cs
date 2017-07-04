using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBillManagementSystem.Models
{
    public class TestDetails
    {
        #region Property
        public string Test { get; set; }

        public decimal Fee { get; set; }

        public string Type { get; set; }

        #endregion


        #region Constructor
        public TestDetails() { }

        public TestDetails(string name,decimal fee,string type) {
            this.Test = name;
            this.Fee = fee;
            this.Type = type;

        }
        #endregion
    }
       
}