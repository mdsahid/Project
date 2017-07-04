using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        //To save data in Teacher table//
        public  bool Save(Teacher teacher)
        {
            dbContext.Teachers.Add(teacher);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
            
        }
        // to get all designations//
        public  List<Designation> GetAllDesignation()
        {
            return dbContext.Designations.ToList();
        }
        //To check uniqueness of eamil//
        public  bool GetTeacherByEmail(string teacherEmail)
        {

            return !dbContext.Teachers.Any(x => x.teacherEmail == teacherEmail);
        }
        //To get all teachers  when select a department in drop down//
        public  List<SelectListItem> GetTeacherByDepartment(string depCode)
        {

            var Teachers= dbContext.Teachers.Where(x => x.depCode == depCode);
            List<SelectListItem> teacherList = new List<SelectListItem>();
            teacherList.Add(new SelectListItem { Value = "", Text = "--Select Teacher--", Selected = true });
            foreach (var teacher in Teachers)
            {
                teacherList.Add(new SelectListItem { Text = teacher.teacherName, Value = teacher.teacherID.ToString() });
            }
            return teacherList;
        }
    }
}