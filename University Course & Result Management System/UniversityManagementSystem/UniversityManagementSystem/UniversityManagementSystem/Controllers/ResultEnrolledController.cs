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
    public class ResultEnrolledController : Controller
    {
       
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        StudentManager studentManager = new StudentManager();
        ResultManager resultManager = new ResultManager();


        //
        // GET: /ResultEnrolled/SaveResult

        public ActionResult SaveResult()
        {
            ViewBag.grades = new SelectList(resultManager.Grade(), "gradeID", "gradeLetter");
            ViewBag.StudentRegNo = new SelectList(studentManager.StudentRegNo(), "StudentID", "RegistrationNo");
            return View();
        }

        //
        // POST: /ResultEnrolled/SaveResult

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveResult(StudentResultEnrolled StudentResult)
        {
            if (ModelState.IsValid)
            {

                if (resultManager.GetCourseEnroll(StudentResult.CourseID, StudentResult.StudentID) != null)
                {

                  bool IsResultEnrolled=  resultManager.SaveResult(StudentResult);
                  if (IsResultEnrolled)
                  {
                      ViewBag.Message = "Result enrolled successfully";
                  }
                  else
                  {
                      ViewBag.errMessage = "Result failed to enroll";
                  }
                  
                }

                else
                {
                    ViewBag.errMessage = "Student doesnt enrolled this Course";
                }
                ModelState.Clear();
            }

            ViewBag.StudentRegNo = new SelectList(studentManager.StudentRegNo(), "StudentID", "RegistrationNo");
            ViewBag.grades = new SelectList(resultManager.Grade(), "gradeID", "gradeLetter");
            return View();
        }

        public ActionResult ViewResult()
        {
            ViewBag.StudentRegNo = new SelectList(studentManager.StudentRegNo(), "StudentID", "RegistrationNo");
            return View();
        }

        public JsonResult GetStudentCourseResult(int StudentId)
        {

            var CourseResult = resultManager.GetStudentCourseResult(StudentId);
            return Json(CourseResult, JsonRequestBehavior.AllowGet);
        }




        public JsonResult GetStudentInfo(int StudentID)
        {


            var Student = studentManager.GetStudentInfo(StudentID);

            return Json(Student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CoursebydepName(string depName)
        {

            var Courses = courseManager.GetCourseByDepName(depName);


            return Json(Courses, JsonRequestBehavior.AllowGet);
        }


    }
}