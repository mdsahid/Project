using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGetway _Getway = new StudentGetway();
        public bool GetStudentByEmail(string studentEmail)
        {
            return _Getway.GetStudentByEmail(studentEmail);
        }

        public bool Save(Student student)
        {
            return _Getway.Save(student);
        }
        public Student GetStudentInfoByEmail(string email)
        {
            return _Getway.GetStudentInfoByEmail(email);
        }

        public List<Student> StudentRegNo()
        {
            return _Getway.StudentRegNo();
        }

        public StudentEnrolledCourse GetCourseEnroll(int CourseID, int StudentID)
        {
            return _Getway.GetCourseEnroll(CourseID, StudentID);
        }

        public bool SaveEnrollCourse(StudentCourseEnroll StudentEnrolled)
        {
            return _Getway.SaveEnrollCourse(StudentEnrolled);
        }

        public StudentCourseEnroll GetStudentInfo(int StudentID)
        {
            return _Getway.GetStudentInfo(StudentID);
        }
    }
}