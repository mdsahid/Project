using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class DepartmentGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        #region Method

        // To save data in Department table//
        public bool Save(Department department)
        {
            dbContext.Departments.Add(department);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
        }


        //To get all department data from department table//
        public  List<Department> GetAllDepartment()
        {
            List<Department> departments = dbContext.Departments.ToList();
            return departments;
        }
        //To check uniqueness of dep code //
        public  bool GetDepartmentByDepCode(string depCode)
        {

            return !dbContext.Departments.Any(x => x.depCode == depCode);
        }
        //To check uniqueness of dep name //
        public  bool GetDepartmentByDepName(string depName)
        {

            return !dbContext.Departments.Any(x => x.depName == depName);
        }

        #endregion
    }
}