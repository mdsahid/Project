using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class StudentGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        
        //To save data in student table//
        public bool Save(Student student)
        {
            student.CurrentYear = Convert.ToString(DateTime.Parse(student.regDate.ToString()).Year);
            dbContext.Students.Add(student);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
        }
        // To show student details after saving a student//
        public Student GetStudentInfoByEmail(string email)
        {
            Student students = dbContext.Students.FirstOrDefault(x => x.studentEmail == email);
            return students;
        }
        // To check uniqueness of email//
        public bool GetStudentByEmail(string studentEmail)
        {

            return !dbContext.Students.Any(x => x.studentEmail == studentEmail);
        }
        // To get all students//
        public List<Student> StudentRegNo()
        {
            return dbContext.Students.ToList();
        }
        // To enroll course to student//
        public bool SaveEnrollCourse(StudentCourseEnroll StudentEnrolled)
        {
            StudentEnrolledCourse enroll = new StudentEnrolledCourse();
            enroll.StudentID = StudentEnrolled.StudentID;
            enroll.CourseID = StudentEnrolled.CourseID;
            enroll.enrolledDate = StudentEnrolled.Dates;
            dbContext.StudentEnrolledCourses.Add(enroll);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
        }
        // To check a course is already enrolled  to a student//
        public StudentEnrolledCourse GetCourseEnroll(int CourseID, int StudentID)
        {

            var Courses = dbContext.StudentEnrolledCourses.FirstOrDefault(x => x.CourseID == CourseID && x.StudentID == StudentID);
            return Courses;

        }
        // To show student info when select a student Id in drop down//
        public StudentCourseEnroll GetStudentInfo(int StudentID)
        {
            var Student = dbContext.Students.Select(x => new StudentCourseEnroll
            {

                StudentID = x.studentID,
                StudentName = x.studentName,
                StudentEmail = x.studentEmail,
                depName = x.Department.depName
            }).SingleOrDefault(x => x.StudentID == StudentID);

            return Student;
        }
    }
}