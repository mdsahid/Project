using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;

namespace DiagonisticCenterBillManagementSystem.Models
{
    #region Class
    public class PatientTestRequest
    {
        #region Property
        public int ID { get; set; }
        public Nullable<int> patientID { get; set; }
        public Nullable<int> TestID { get; set; }

        #endregion
        #region Constructor
        public PatientTestRequest() { }
        public PatientTestRequest(int patientID, int testID)
        {
            this.patientID = patientID;
            this.TestID = testID;
        }
        #endregion

    }//cs
    #endregion
}//ns