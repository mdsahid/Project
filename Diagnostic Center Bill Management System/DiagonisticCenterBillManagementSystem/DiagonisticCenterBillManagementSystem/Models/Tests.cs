using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;
namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    [Serializable]

    public class Tests
    {
        #region Property
        public int ID { get; set; }
        public string tName { get; set; }
        public decimal testFee { get; set; }
        public Nullable<int> typeID { get; set; }

        #endregion

        #region Constructor
        public Tests()
        {

        }
        public Tests(string tName, decimal testFee, int typeId)
        {
            this.tName = tName;
            this.testFee = testFee;
            this.typeID = typeId;
        }
        #endregion

    }//cs
    #endregion
}//ns