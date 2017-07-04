using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagonisticCenterBillManagementSystem.Models;
using DiagonisticCenterBillManagementSystem.DAL;
namespace DiagonisticCenterBillManagementSystem.BLL
{
    public class TestTypeManager:TypeGetway
    {
        TypeGetway typeGeteay = new TypeGetway();

        public override int AddType(Types testType)
        {
            if (IsTypeNameExist(testType.TypeName))
            {
                throw new Exception("Test type name is already exist");
            }
            if (testType.TypeName == null || testType.TypeName == "")
            {
                throw new Exception("Please write type name");
            }
            
            return base.AddType(testType);
        }



        public override List<TypeReports> GetReportByTypeName(DateTime fromDate, DateTime toDate)
        {
            return base.GetReportByTypeName(fromDate, toDate);
        }


        public override List<Types> GetAllTestType()
        {
            return base.GetAllTestType();
        }
        public override Types GetTestTypeByName(string Name)
        {
            return base.GetTestTypeByName(Name);
        }


        public bool IsTypeNameExist(string typeName)
        {
            bool isTypeNameExist = false;
            Types testType = GetTestTypeByName(typeName);
            if (testType != null)
            {
                isTypeNameExist = true;
            }
            return isTypeNameExist;

        }
        
   }
}