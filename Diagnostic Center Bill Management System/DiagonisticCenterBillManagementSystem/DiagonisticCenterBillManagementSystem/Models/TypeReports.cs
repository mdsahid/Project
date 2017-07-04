using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    public class TypeReports
    {
        #region Property
        public string TypeName { get; set; }

        public int TotalTest { get; set; }

        public decimal TotalAmount { get; set; }

        #endregion

        #region Constructor
        public TypeReports() { }

        public TypeReports(string typeName,int totalTest,decimal totalAmount)
        {
            this.TypeName = typeName;
            this.TotalTest = totalTest;
            this.TotalAmount = totalAmount;
        }
        #endregion

    }
        #endregion
}