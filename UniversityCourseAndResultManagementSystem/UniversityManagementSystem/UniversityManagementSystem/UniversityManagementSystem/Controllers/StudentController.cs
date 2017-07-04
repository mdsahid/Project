using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {

        private DepartmentManager departmentManager = new DepartmentManager();
        private StudentManager studentManager = new StudentManager();
        //
        // GET: /Student/




        //
        // GET: /Student/Save

        public ActionResult Save()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            return View();
        }

        //
        // POST: /Student/Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {

            student.CurrentYear = Convert.ToString(DateTime.Parse(student.regDate.ToString()).Year);

            if (ModelState.IsValid)
            {
                bool IsStudentRegistered = studentManager.Save(student);
                if (IsStudentRegistered)
                {
                    Student students = studentManager.GetStudentInfoByEmail(student.studentEmail);
                    ViewBag.student = students;
                }
                else
                {
                    ViewBag.errMessage = "Student failed to register";
                }
            }

            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.departments = new SelectList(departments, "depCode", "depName");
            return View(student);
        }

        public JsonResult IsEmailExits(string studentEmail)
        {
            return Json(studentManager.GetStudentByEmail(studentEmail), JsonRequestBehavior.AllowGet);
        }


    }
}