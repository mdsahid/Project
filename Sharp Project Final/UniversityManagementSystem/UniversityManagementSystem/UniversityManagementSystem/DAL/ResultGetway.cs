using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class ResultGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        // to save result in student result table//
        public bool SaveResult(StudentResultEnrolled StudentResult)
        {
            Result result = new Result();
            result.StudentID = StudentResult.StudentID;
            result.gradeID = StudentResult.gradeID;
            result.CourseID = StudentResult.CourseID;

            dbContext.Results.Add(result);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
        }

        // To view the student result //
        public  List<ResultViewModel> GetStudentCourseResult(int StudentId)
        {
            var CourseResult = from course in dbContext.StudentEnrolledCourses
                               join result in dbContext.Results
                               on course.CourseID equals result.CourseID

                               into egroup
                               from groups in egroup.DefaultIfEmpty()
                               where course.StudentID == StudentId
                               select new ResultViewModel
                               {

                                   CourseCode = course.Course.CourseCode,
                                   CourseName = course.Course.CourseName,
                                   CourseGrade = groups == null ? "Not graded yet" : groups.Grade.gradeLetter

                               };

            return CourseResult.ToList();
        }
        // To get enroll course by studentID and CourseID to check if Course already enrolled to this studentID//
        public  StudentEnrolledCourse GetCourseEnroll(int? CourseID, int? StudentID)
        {

            var Courses = dbContext.StudentEnrolledCourses.FirstOrDefault(x => x.CourseID == CourseID && x.StudentID == StudentID);
            return Courses;

        }
        //To get all grade//
        public  List<Grade> Grade()
        {
            var GradeList = dbContext.Grades.ToList();
            return GradeList;
        }

        public Result GetEnrollStudentResult(int? StudentID, int? CourseID)
        {
          return  dbContext.Results.FirstOrDefault(x => x.StudentID == StudentID && x.CourseID == CourseID);
        }
    }
}