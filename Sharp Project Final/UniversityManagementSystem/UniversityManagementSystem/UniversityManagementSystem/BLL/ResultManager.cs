using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class ResultManager
    {
        ResultGetway _Getway = new ResultGetway();
        public  List<ResultViewModel> GetStudentCourseResult(int StudentId)
        {
            return _Getway.GetStudentCourseResult(StudentId);
        }

        public  bool SaveResult(StudentResultEnrolled StudentResult)
        {
            return _Getway.SaveResult(StudentResult);
        }

        public  StudentEnrolledCourse GetCourseEnroll(int? CourseID, int? StudentID)
        {
            return _Getway.GetCourseEnroll(CourseID, StudentID);
        }

        public  List<Grade> Grade()
        {
            return _Getway.Grade();
        }

        public Result GetEnrollStudentResult(int? StudentID, int? CourseID)
        {
            return _Getway.GetEnrollStudentResult(StudentID, CourseID);
        }
    }
}