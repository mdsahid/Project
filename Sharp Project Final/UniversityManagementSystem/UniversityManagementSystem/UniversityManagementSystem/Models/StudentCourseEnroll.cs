using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class StudentCourseEnroll
    {
        [Required(ErrorMessage = "Select a student Reg No")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Select a student Reg No")]
        [Display(Name = "Student Reg No")]
        public int StudentRegNo { get; set; }
       [Display(Name="Name")]
        public string StudentName { get; set; }
        [Display(Name = "Email")]
        public string StudentEmail { get; set; }
         [Display(Name = "Department")]
        public string depName { get; set; }
        [Required(ErrorMessage = "Select a Course")]
        [Display(Name = "Course")]
        public virtual int CourseID { get; set; }
        //[Required]
         [Required(ErrorMessage = "Date is required")]
         [Display(Name = "Date")]
        public DateTime Dates { get; set; }
    }
}