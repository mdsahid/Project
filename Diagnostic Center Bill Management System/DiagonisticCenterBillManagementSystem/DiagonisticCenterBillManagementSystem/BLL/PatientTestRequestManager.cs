using DiagonisticCenterBillManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;

namespace DiagonisticCenterBillManagementSystem.BLL
{
    public class PatientTestRequestManager:PatientTestRequestGetway
    {
        PatientTestRequestGetway testRequestGatway = new PatientTestRequestGetway();

        public override int AddTestRequest(PatientTestRequest testRequest)
        {
            return base.AddTestRequest(testRequest);
        }



        public override List<PatientTestRequest> GetAllTestRequest()
        {
            return base.GetAllTestRequest();
        }
    }
}