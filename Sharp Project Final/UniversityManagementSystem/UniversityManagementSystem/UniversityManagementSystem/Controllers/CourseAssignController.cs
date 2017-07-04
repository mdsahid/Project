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
    public class CourseAssignController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        private DepartmentManager departmentManager = new DepartmentManager();
        private CourseManager courseManager = new CourseManager();
        private TeacherManager teacherManager = new TeacherManager();
        private CourseAssignManager cAssignManager = new CourseAssignManager();
        //
        // GET: /CourseAssign/

        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.Course).Include(c => c.Department).Include(c => c.Teacher);
            return View(courseassigns.ToList());
        }
        [HttpGet]
        public ActionResult CourseStatics()
        {

            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            return View();

        }

        public JsonResult GetCourseStatics(string depCode)
        {
            List<CourseStatics> courseStatics = cAssignManager.GetCourseStatics(depCode);

            return Json(courseStatics, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /CourseAssign/SaveCourseAssign
        [HttpGet]
        public ActionResult SaveCourseAssign()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourseAssign(CourseAssign courseassign)
        {

            if (ModelState.IsValid)
            {
                if (GetAssignCourse(courseassign.CourseID) == null)
                {
                    bool IsCourseAssign = cAssignManager.Save(courseassign);
                    if (IsCourseAssign)
                    {
                        ViewBag.Message = "Course assigned successfully";
                    }
                    else
                    {
                        ViewBag.errMessage = "Course assigned failed";
                    }

                }
                else
                {
                    ViewBag.errMessage = "Course is already assigned";
                }
                ModelState.Clear();
            }

            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            return View();
        }

        public CourseAssign GetAssignCourse(int? CourseID)
        {
            return db.CourseAssigns.SingleOrDefault(x => x.CourseID == CourseID);
        }

        public JsonResult GetTeacherByDepartment(string depCode)
        {
            var teachers = teacherManager.GetTeacherByDepartment(depCode);

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartment(string depCode)
        {
            var Courses = courseManager.GetCourseByDepartment(depCode);

            return Json(Courses, JsonRequestBehavior.AllowGet);
        }



        public JsonResult TeacherCredit(int TeacherId)
        {
            var techerCredit = cAssignManager.GetTeacherCredit(TeacherId);
            return Json(techerCredit, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CourseInfo(int CourseID)
        {
            var Course = db.Courses.Select(x => new
            {
                courseId = x.courseId,
                CourseName = x.CourseName,
                CourseCredit = x.CourseCredit
            }).FirstOrDefault(x => x.courseId == CourseID);

            return Json(Course, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UnassignCourse()
        {

            return View();
        }

        public ActionResult UnassignCourse(CourseAssign courseAssign)
        {
            if (!cAssignManager.GetAllassignCourse())
            {
                bool IsCourseUnassigned = cAssignManager.UnassignCourse(courseAssign);
                if (IsCourseUnassigned)
                {
                    ViewBag.Message = "All courses are Unassigned successfully";
                }
                else
                {
                    ViewBag.errorMessage = "All courses failed to Unassign";
                }

            }
            else
            {
                ViewBag.errorMessage = "All courses already Unassigned";
            }

            return View();
        }

    }

}