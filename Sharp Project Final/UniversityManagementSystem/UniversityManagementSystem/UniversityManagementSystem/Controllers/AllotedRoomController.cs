using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllotedRoomController : Controller
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        private CourseManager courseManager = new CourseManager();
        private RoomManager roomManager = new RoomManager();
        private DepartmentManager departmentManager = new DepartmentManager();


        //
        // GET: /AllotedRoom/Create

        public ActionResult AllocateRoom()
        {
            ViewBag.days = new SelectList(roomManager.GetAllDay(), "dayID", "daysName");
            ViewBag.departments = new SelectList(departmentManager.GetAllDepartment(), "depCode", "depName");
            ViewBag.rooms = new SelectList(roomManager.GetAllRoom(), "roomID", "roomName");
            return View();
        }



        //
        // POST: /AllotedRoom/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateRoom(RoomAlloted allotedroom)
        {

            if (ModelState.IsValid)
            {
                if (!roomManager.CheckTimeOverlapping(allotedroom))
                {
                    if (roomManager.CheckFromTimeGreaterToTime(allotedroom))
                    {
                        bool IsAllocated = roomManager.AllocateRoom(allotedroom);
                        if (IsAllocated)
                        {
                            ViewBag.Message = "Class room allocated successfully";
                        }
                        else
                        {
                            ViewBag.errMessage = "Class room failed allocate";
                        }

                    }
                    else
                    {
                        ViewBag.errMessage = "Starting time is greater than end Time";
                    }
                }
                else
                {
                    ViewBag.errMessage = "Class room is already scheduled";
                }
                ModelState.Clear();
            }


            ViewBag.days = new SelectList(roomManager.GetAllDay(), "dayID", "daysName");
            ViewBag.departments = new SelectList(departmentManager.GetAllDepartment(), "depCode", "depName");
            ViewBag.rooms = new SelectList(roomManager.GetAllRoom(), "roomID", "roomName");

            return View();
        }

        public JsonResult GetCourseByDepartment(string depCode)
        {
            var Courses = courseManager.GetCourseByDepartment(depCode);

            return Json(Courses, JsonRequestBehavior.AllowGet);
        }



        public ActionResult CourseSchedule(string depCode)
        {
            ViewBag.departments = new SelectList(departmentManager.GetAllDepartment(), "depCode", "depName");

            var courses = courseManager.GetCoursedepCode(depCode);
            List<string> Code = new List<string>();
            List<string> Name = new List<string>();
            foreach (var item in courses)
            {
                Name.Add(item.CourseName);
                Code.Add(item.CourseCode);
            }
            ViewBag.CourseCode = Code;
            ViewBag.CourseName = Name;
            ViewBag.Schedules = roomManager.CourseSchedule(depCode); ;
            return View();
        }



        [HttpGet]
        public ActionResult UnallocateClassRoom()
        {
            //var AllotedRooms = roomManager.GetAllAllotedRoom();
            return View();
        }

        public ActionResult UnallocateClassRoom(AllotedRoom AllotedRoom)
        {
            if (!roomManager.GetAllAllotedRoom())
            {
                bool IsUpdateRoomAllocation = roomManager.UpdateAllocateClassroom(AllotedRoom);
                if (IsUpdateRoomAllocation)
                {
                    ViewBag.Message = "All rooms are Unallocated successfully";
                }

                else
                {
                    ViewBag.errorMessage = "Failed to Unallocate";
                }
            }
            else
            {
                ViewBag.errorMessage = "All rooms already Unallocated";
            }

            return View();
        }
    }
}