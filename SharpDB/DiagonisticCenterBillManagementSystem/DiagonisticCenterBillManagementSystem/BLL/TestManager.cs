using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.DAL;
using DiagonisticCenterBillManagementSystem.Models;
namespace DiagonisticCenterBillManagementSystem.BLL
{
    public class TestManager:TestGatway
    {
        TestGatway testGeteay = new TestGatway();

        public override int AddTest(Tests test)
        {
            if (IsTestNameExist(test.tName))
            {
                throw new Exception("Test name is already exist");
            }
            if (test.tName == null || test.tName == "")
            {
                throw new Exception("Please write test name");
            }

            return base.AddTest(test);
        }
        public override List<Tests> GetAllTest()
        {
            return base.GetAllTest();
        }



        public override List<TestDetails> GetAllTestWithType()
        {
            return base.GetAllTestWithType();
        }


        public override List<TestReports> GetReportByTestName(DateTime fromDate, DateTime toDate)
        {
            return base.GetReportByTestName(fromDate, toDate);
        }


        public override Tests GetTestByName(string Name)
        {
            return base.GetTestByName(Name);
        }


        public bool IsTestNameExist(string tName)
        {
            bool isTestNameExist = false;
            Tests testName = GetTestByName(tName);
            if (testName != null)
            {
                isTestNameExist = true;
            }
            return isTestNameExist;

        }
    }
}