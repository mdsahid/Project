using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;


namespace UniversityManagementSystem.BLL
{
   
    public class CourseAssignManager
    {
        CourseAssignGetway _Getway = new CourseAssignGetway();
        public bool Save(CourseAssign courseAssign)
        {
          return _Getway.Save(courseAssign);
        }

        public List<CourseStatics> GetCourseStatics(string depCode)
        {
            return _Getway.GetCourseStatics(depCode);
        }
        public  CourseAssignViewModel GetTeacherCredit(int TeacherId)
        {
            return _Getway.GetTeacherCredit(TeacherId);
        }

        public bool GetAllassignCourse()
        {
            return _Getway.GetAllassignCourse();
        }

        public  bool UnassignCourse(CourseAssign courseAssign)
        {
          return  _Getway.UnassignCourse(courseAssign);
        }
    }
}