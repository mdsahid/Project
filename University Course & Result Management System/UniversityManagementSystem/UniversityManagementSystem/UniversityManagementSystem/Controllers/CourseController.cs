using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.BLL;
namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        private CourseManager courseManager = new CourseManager();
        private DepartmentManager departmentManager = new DepartmentManager();





        // GET: /Course/Save

        public ActionResult Save()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            List<Semester> semesters = courseManager.GetAllSemester();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            ViewBag.semesters = new SelectList(semesters, "SemesterID", "SemesterName");
            return View();
        }

        //
        // POST: /Course/Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                bool IsCourseSaved = courseManager.Save(course);
                if (IsCourseSaved)
                {
                    ViewBag.Message = "Course saved successfully";
                }
                else
                {
                    ViewBag.errMessage = "Course failed to save";
                }
                ModelState.Clear();

            }
            List<Department> departments = departmentManager.GetAllDepartment();
            List<Semester> semesters = courseManager.GetAllSemester();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            ViewBag.semesters = new SelectList(semesters, "SemesterID", "SemesterName");
            return View();
        }

        public JsonResult IsCodeExits(string CourseCode)
        {
            return Json(courseManager.GetCourseByCode(CourseCode), JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsNameExits(string CourseName)
        {
            return Json(courseManager.GetCourseByName(CourseName), JsonRequestBehavior.AllowGet);
        }



    }
}