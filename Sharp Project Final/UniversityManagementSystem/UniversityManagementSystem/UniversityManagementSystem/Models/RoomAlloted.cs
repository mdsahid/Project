using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Common;
namespace UniversityManagementSystem.Models
{
    //    [MetadataType(typeof(RoomAlloted))]
    //    public partial class AllotedRoom
    //    {

    //    }
    public class RoomAlloted
    {
        [Required(ErrorMessage = "Please Select a department.")]
        [Display(Name = "Department")]
        public string depCode { get; set; }
        [Required(ErrorMessage = "Please Select a Course.")]
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "Please Select a Room.")]
        [DisplayName("Room No.")]
        public int roomID { get; set; }
        [Required(ErrorMessage = "Please Select a Day.")]
        [DisplayName("Day")]
        public int dayID { get; set; }
        [Required(ErrorMessage = "Start time is required")]
        //[DataType(DataType.Time, ErrorMessage = "Please, input time like as 12:00")]
        [RegularExpression("^(0[1-9]|1[0-2]):[0-5][0-9]", ErrorMessage = "Time is invalid")]
        public string Form { get; set; }
        [Required(ErrorMessage = "Please select AM/PM")]
        public string StartPeriod { get; set; }
        [Required(ErrorMessage = "End time is required")]
        //[DataType(DataType.Time, ErrorMessage = "Please, input time like as 12:00")]
        [RegularExpression("^(0[1-9]|1[0-2]):[0-5][0-9]",ErrorMessage="Time is invalid")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please select AM/PM")]
        public string EndPeriod { get; set; }
        public string FormTime()
        {
            return (Form + " " + StartPeriod);
        }

        public string EndTime()
        {
            return (To + " " + EndPeriod);
        }


    }
}
