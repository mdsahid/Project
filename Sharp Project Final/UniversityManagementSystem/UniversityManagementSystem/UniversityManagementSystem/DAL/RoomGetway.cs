using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;
namespace UniversityManagementSystem.DAL
{
    public class RoomGetway
    {
        UniversityDBEntities dbContext = new UniversityDBEntities();
        //To save data in AllocateRoom table//
        public bool AllocateRoom(RoomAlloted allotedroom)
        {
            AllotedRoom alloted = new AllotedRoom();
            alloted.Assign = true;
            alloted.depCode = allotedroom.depCode;
            alloted.CourseID = allotedroom.CourseID;
            alloted.dayID = allotedroom.dayID;
            alloted.roomID = allotedroom.roomID;
            alloted.fromTime = allotedroom.FormTime();
            alloted.toTime = allotedroom.EndTime();

            dbContext.AllotedRooms.Add(alloted);
            int rowaffected = dbContext.SaveChanges();
            return rowaffected > 0;

        }

        //To Get all Room data//
        public  List<Room> GetAllRoom()
        {
            List<Room> rooms = dbContext.Rooms.ToList();
            return rooms;
        }
        //To Get all days data//
        public  List<AllotedDay> GetAllDay()
        {
            List<AllotedDay> days = dbContext.AllotedDays.ToList();
            return days;
        }
        //To check time overlapping when aalocating room for class//
        public  bool CheckTimeOverlapping(RoomAlloted room)
        {
            DateTime fromInsertDaytime = DateTime.ParseExact(room.FormTime(), "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan fromInsertTime = fromInsertDaytime.TimeOfDay;
            DateTime toInsertDayTime = DateTime.ParseExact(room.EndTime(), "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan toInsertTime = toInsertDayTime.TimeOfDay;



            bool checkTime = false;
            var allotedTime = dbContext.AllotedRooms.Where(x => x.roomID == room.roomID && x.dayID == room.dayID).Select(x => new
            {
                fromTime = x.fromTime,
                toTime = x.toTime
            });

            foreach (var time in allotedTime)
            {
                DateTime fromDayTime = DateTime.ParseExact(time.fromTime.ToString(), "hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan fromTime = fromDayTime.TimeOfDay;
                DateTime toIDayTime = DateTime.ParseExact(time.toTime.ToString(), "hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan toTime = toIDayTime.TimeOfDay;
                if (fromInsertTime >= fromTime && fromInsertTime < toTime)
                {
                    checkTime = true;
                    break;
                }
                else if (fromTime > toInsertTime && toInsertTime >= toTime)
                {
                    checkTime = true;
                    break;
                }
                else
                {
                    checkTime = false;
                }
            }
            return checkTime;
        }
        //To unallocate Classroom //
        public bool UpdateAllocateClassroom(AllotedRoom AllotedRoom)
        {
            var AllotedRooms = dbContext.AllotedRooms.Where(x => x.Assign == true);
            foreach (var item in AllotedRooms)
            {
                item.Assign = false;
            }
          int rowaffected= dbContext.SaveChanges();
          return rowaffected > 0;
        }
        //To get all alloted room  for checking//
        public  bool GetAllAllotedRoom()
        {
            var AllotedRooms = !dbContext.AllotedRooms.Any(x => x.Assign == true);
            return AllotedRooms;
        }
        //To get all assign room for course schedule //
        public List<AllotedRoom> GetAllAssigneRoom()
        {
            var Allocatioons = dbContext.AllotedRooms.Where(x => x.Assign == true).ToList();
            return Allocatioons;
        }
    }

}
