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
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        //
        // GET: /Department/

        public ActionResult GetAllDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            return View(departments);
        }

       
        //
        // GET: /Department/Save

        public ActionResult Save()
        {
            return View();
        }

        //
        // POST: /Department/Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
              bool IsDepartmentSaved=  departmentManager.Save(department);
              if (IsDepartmentSaved)
              {
                  ViewBag.Message = "Saved department successfully";
              }
              else
              {
                  ViewBag.errMessage = "failed to save department";
              }
                ModelState.Clear();
               
              
            }
          
            return View();
        }

        public JsonResult IsCodeExits(string depCode)
        {
            return Json(departmentManager.GetDepartmentByDepCode(depCode),JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsNameExits(string depName)
        {
            return Json(departmentManager.GetDepartmentByDepName(depName),JsonRequestBehavior.AllowGet);
        }

        
       
       
    }
}