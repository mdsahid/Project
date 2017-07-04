using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class StudentResultEnrolled
    {
        public int resultID { get; set; }
        public int StudentID { get; set; }
         [Display(Name = "Course")]
         [Required(ErrorMessage = "Select a course")]
        public int CourseID { get; set; }
         [Display(Name = "Grade")]
         [Required(ErrorMessage = "Select a grade.")]
        public int gradeID { get; set; }
         [Display(Name = "Student Reg No")]
         [Required(ErrorMessage = "Select a student registration No.")]
        public int StudentRegNo { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
         [Display(Name = "Email")]
        public string StudentEmail { get; set; }
        [Display(Name="Department")]
        public string depName { get; set; }

    }
}