using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class CourseAssignGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        
        //To assign course in Course assign table//
        public bool Save(CourseAssign courseAssign)
        {
            courseAssign.Assign = true;
            dbContext.CourseAssigns.Add(courseAssign);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;
        }
        //To get all course statics from course,course assign,semester and teacher table//
        public List<CourseStatics> GetCourseStatics(string depCode)
        {

            var CourseStatics = from course in dbContext.Courses
                                join courseAssign in dbContext.CourseAssigns
                                on course.courseId equals courseAssign.CourseID
                               into egroup
                                from courseAssign in egroup.DefaultIfEmpty()
                                select new
                                {
                                    course,

                                    teacherName = courseAssign.Teacher == null || courseAssign.Assign == false ? "Not yet assigned" : courseAssign.Teacher.teacherName
                                } into egroup

                                join department in dbContext.Departments
                                on egroup.course.depCode equals department.depCode
                                where department.depCode == depCode

                                select new CourseStatics

                                {
                                    CourseCode = egroup.course.CourseCode,
                                    CourseName = egroup.course.CourseName,
                                    SemesterName = egroup.course.Semester.SemesterName,
                                    TeacherName = egroup.teacherName


                                };

            return CourseStatics.ToList();

        }
        //To get calculation of teacher credit and remaining credit when course assigned//
        public CourseAssignViewModel GetTeacherCredit(int TeacherId)
        {
            var teacherCredit = dbContext.Teachers.SingleOrDefault(x => x.teacherID == TeacherId).CreditToBeTaken;

            Console.WriteLine(teacherCredit);

            var teacherCredits = dbContext.CourseAssigns.Join(dbContext.Courses, x => x.CourseID, y => y.courseId, (x, y) => new
            {
                courseCredit = y.CourseCredit,
                teacherID = x.TeacherID

            }).Where(x => x.teacherID == TeacherId);
            double assCredit = 0;
            foreach (var item in teacherCredits)
            {
                assCredit += Convert.ToDouble(item.courseCredit);
            }
            CourseAssignViewModel assign = new CourseAssignViewModel();
            assign.TeacherCredit = Convert.ToDouble(teacherCredit);
            assign.RemainingCredit = Convert.ToDouble(teacherCredit) - assCredit;
            return assign;

        }
        //To unassign course//
        public bool UnassignCourse(CourseAssign courseAssign)
        {
            var CourseAssigns = dbContext.CourseAssigns.Where(x => x.Assign == true);
            foreach (var item in CourseAssigns)
            {
                item.Assign = false;
            }
           int rowaffected= dbContext.SaveChanges();

           return rowaffected > 0;
        }
        //To get all assigned course data//
        public bool GetAllassignCourse()
        {
            var CourseAssigns = !dbContext.CourseAssigns.Any(x => x.Assign == true);
            return CourseAssigns;
        }
    }
}