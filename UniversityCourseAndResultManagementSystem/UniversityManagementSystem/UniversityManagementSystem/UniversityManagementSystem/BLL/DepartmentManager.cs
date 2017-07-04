using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGetway _Getway = new DepartmentGetway();
        public  bool Save(Department department)
        {
           return _Getway.Save(department);
        }

        public  List<Department> GetAllDepartment()
        {
            return _Getway.GetAllDepartment();
        }

        public  bool GetDepartmentByDepCode(string depCode)
        {
            return _Getway.GetDepartmentByDepCode(depCode);
        }

        public  bool GetDepartmentByDepName(string depName)
        {
            return _Getway.GetDepartmentByDepName(depName);
        }
    }
}