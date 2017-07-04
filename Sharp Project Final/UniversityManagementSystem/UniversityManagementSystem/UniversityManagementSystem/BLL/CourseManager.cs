using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.DAL;
namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGetway _Getway = new CourseGetway(); 
        public  bool Save(Course course)
        {
           return _Getway.Save(course);
        }
        public  List<Semester> GetAllSemester()
        {
            return _Getway.GetAllSemester();
        }
        public  bool GetCourseByName(string CourseName)
        {
            return _Getway.GetCourseByName(CourseName);
        }
        public  bool GetCourseByCode(string CourseCode)
        {
            return _Getway.GetCourseByCode(CourseCode);
        }

        public  List<SelectListItem> GetCourseByDepartment(string depCode)
        {
            return _Getway.GetCourseByDepartment(depCode);
        }
        public  List<SelectListItem> GetCourseByDepName(string depName)
        {
            return _Getway.GetCourseByDepName(depName);
        }

        public  List<Course> GetCoursedepCode(string depCode)
        {
            return _Getway.GetCoursedepCode(depCode);
        }
        //public override Course CourseInfo(int CourseID)
        //{
        //    return base.CourseInfo(CourseID);
        //}
       
    }
}