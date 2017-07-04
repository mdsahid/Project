using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class CourseGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        //To save data in course table//
        public bool Save(Course course)
        {
            dbContext.Courses.Add(course);
        int rowaffeced=dbContext.SaveChanges();

        return rowaffeced > 0;
        }
        //To get all semester//
         public List<Semester> GetAllSemester()
        {
            return dbContext.Semesters.ToList();
        }
        //To check uniqueness of course code//
         public  bool GetCourseByCode(string CourseCode)
         {

             return !dbContext.Courses.Any(x => x.CourseCode == CourseCode);
         }
         //To check uniqueness of course name//
         public  bool GetCourseByName(string CourseName)
         {

             return !dbContext.Courses.Any(x => x.CourseName == CourseName);
         }

        // To get all course by department code//
        public  List<Course> GetCoursedepCode(string depCode)
         {
             return dbContext.Courses.Where(x => x.depCode == depCode).ToList();
         }
        // To get all course by department code for releted drop down//
         public  List<SelectListItem> GetCourseByDepartment(string depCode)
         {

            var Courses=dbContext.Courses.Where(x => x.depCode == depCode);
            List<SelectListItem> CourseList = new List<SelectListItem>();
            CourseList.Add(new SelectListItem { Value = "", Text = "--Select Course--", Selected = true });
            foreach (var course in Courses)
            {
                CourseList.Add(new SelectListItem { Text = course.CourseCode, Value = course.courseId.ToString() });
            }
            return CourseList;
         }
         // To get all course by department name for releted drop down//
         public  List<SelectListItem> GetCourseByDepName(string depName)
         {

             var Courses = dbContext.Courses.Where(x => x.Department.depName == depName);
             List<SelectListItem> CourseList = new List<SelectListItem>();
             CourseList.Add(new SelectListItem { Value = "", Text = "--Select Course--", Selected = true });
             foreach (var course in Courses)
             {
                 CourseList.Add(new SelectListItem { Text = course.CourseCode, Value = course.courseId.ToString() });
             }
             return CourseList;
         }
        

      
    }
}