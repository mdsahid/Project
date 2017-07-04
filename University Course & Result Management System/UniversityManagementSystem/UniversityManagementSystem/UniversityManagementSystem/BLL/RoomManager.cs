using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.BLL
{
    public class RoomManager 
    {
        private UniversityDBEntities db = new UniversityDBEntities();
        CourseGetway courseGetway = new CourseGetway();
        RoomGetway roomGetway = new RoomGetway();
        public bool AllocateRoom(RoomAlloted allotedroom)
        {
          return  roomGetway.AllocateRoom(allotedroom);
        }

        public  List<AllotedDay> GetAllDay()
        {
            return roomGetway.GetAllDay();
        }

        public  List<Room> GetAllRoom()
        {
            return roomGetway.GetAllRoom();
        }

        public bool CheckFromTimeGreaterToTime(RoomAlloted room)
        {
            DateTime fromInsertDayTime = DateTime.ParseExact(room.FormTime(), "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan fromTime = fromInsertDayTime.TimeOfDay;
            DateTime toInsertDayTime = DateTime.ParseExact(room.EndTime(), "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan toTime = toInsertDayTime.TimeOfDay;
            if (toTime > fromTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool CheckTimeOverlapping(RoomAlloted room)
        {
            return roomGetway.CheckTimeOverlapping(room);
        }

        public  bool UpdateAllocateClassroom(AllotedRoom AllotedRoom)
        {
           return roomGetway.UpdateAllocateClassroom(AllotedRoom);
        }

        public  bool GetAllAllotedRoom()
        {
            return roomGetway.GetAllAllotedRoom();
        }

        public List<string> CourseSchedule(string depCode)
        {
            
            var CourseList = courseGetway.GetCoursedepCode(depCode);
            var Allocatioons = roomGetway.GetAllAssigneRoom();
            CourseSchedule courseSchedule = new Models.CourseSchedule();
            List<string> CourseSchedule = new List<string>();
            List<string> Code = new List<string>();
            List<string> Name = new List<string>();
            foreach (var course in CourseList)
            {
                string Schedule = "";
                foreach (var allocate in Allocatioons)
                {
                   
                    if (course.courseId == allocate.CourseID)
                    {
                     
                        Room room = db.Rooms.SingleOrDefault(x => x.roomID == allocate.roomID);
                        AllotedDay day = db.AllotedDays.SingleOrDefault(x => x.dayID == allocate.dayID);
                        allocate.Room = room;
                        allocate.AllotedDay = day;
                        Schedule +="R-No: "+ room.roomName + " , " + day.daysName + " , " + allocate.fromTime + " - " + allocate.toTime + ";   "; 



                    }
                }
                if (Schedule == "")
                {
                    Schedule += "not yet scheduled";
                }
              
                CourseSchedule.Add(Schedule);
            }
            return CourseSchedule;
           
        }



       
       
    }


}