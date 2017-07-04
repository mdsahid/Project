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
    public class TeacherController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        private DepartmentManager departmentManager = new DepartmentManager();
        private TeacherManager teacherManager = new TeacherManager();
        //
        // GET: /Teacher/




        //
        // GET: /Teacher/Save

        public ActionResult Save()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            List<Designation> designation = teacherManager.GetAllDesignation();
            ViewBag.designation = new SelectList(designation, "designationID", "designationName");

            return View();
        }

        //
        // POST: /Teacher/Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                bool IsTeacherSaved = teacherManager.Save(teacher);
                if (IsTeacherSaved)
                {
                    ViewBag.Message = "Teacher registered successfully";
                }
                else
                {
                    ViewBag.errMessage = "Teacher failed to register";
                }
                ModelState.Clear();

            }

            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            List<Designation> designation = teacherManager.GetAllDesignation();
            ViewBag.designation = new SelectList(designation, "designationID", "designationName");
            return View();
        }

        public JsonResult IsEmailExits(string teacherEmail)
        {

            return Json(teacherManager.GetTeacherByEmail(teacherEmail), JsonRequestBehavior.AllowGet);
        }



    }
}