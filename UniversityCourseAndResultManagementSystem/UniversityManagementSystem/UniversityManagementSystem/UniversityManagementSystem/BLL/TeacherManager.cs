using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGetway _Getway = new TeacherGetway();
        public  List<Designation> GetAllDesignation()
        {
            return _Getway.GetAllDesignation();
        }

        public  bool Save(Teacher teacher)
        {
           return _Getway.Save(teacher);
        }
        public  bool GetTeacherByEmail(string teacherEmail)
        {
            return _Getway.GetTeacherByEmail(teacherEmail);
        }

        public  List<SelectListItem> GetTeacherByDepartment(string depCode)
        {
            return _Getway.GetTeacherByDepartment(depCode);
        }
    }
}