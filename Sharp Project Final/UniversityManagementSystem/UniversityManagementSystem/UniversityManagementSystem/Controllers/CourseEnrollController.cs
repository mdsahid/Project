using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseEnrollController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        StudentManager studentManager = new StudentManager();


        //
        // GET: /CourseEnroll/SaveEnrollCourse

        public ActionResult SaveEnrollCourse()
        {


            ViewBag.StudentRegNo = new SelectList(studentManager.StudentRegNo(), "StudentID", "RegistrationNo");
            return View();
        }

        //
        // POST: /CourseEnroll/SaveEnrollCourse

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEnrollCourse(StudentCourseEnroll StudentEnrolled)
        {

            if (studentManager.GetCourseEnroll(StudentEnrolled.CourseID, StudentEnrolled.StudentID) == null)
            {


                if (ModelState.IsValid)
                {
                    bool IsCourseEnrolled = studentManager.SaveEnrollCourse(StudentEnrolled);
                    if (IsCourseEnrolled)
                    {
                        ViewBag.Message = "Student enrolled a course  successfully";
                    }
                    else
                    {
                        ViewBag.errMessage = "Course is failed to enroll";

                    }
                }

            }

            else
            {
                ViewBag.errMessage = "Course is already enrolled";
            }
            ModelState.Clear();
            ViewBag.StudentRegNo = new SelectList(studentManager.StudentRegNo(), "StudentID", "RegistrationNo");
            return View();
        }

        public JsonResult GetStudentInfo(int StudentID)
        {
            var student = studentManager.GetStudentInfo(StudentID);

            return Json(student, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCourseByDepartment(string depCode)
        {
            var Courses = courseManager.GetCourseByDepartment(depCode);

            return Json(Courses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByDepName(string depName)
        {
            var Courses = courseManager.GetCourseByDepName(depName);

            return Json(Courses, JsonRequestBehavior.AllowGet);
        }

    }
}