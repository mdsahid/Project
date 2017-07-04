using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniversityManagementSystem.Common;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssignViewModel
    {
        [Display(Name = "Department")]
        [Required(ErrorMessage="Select a department")]
        public string depCode { get; set; }
        [Display(Name = "Teacher")]
        [Required(ErrorMessage = "Select a teacher")]
        public int TeacherID { get; set; }
        [ReadOnly(true)]
        [Display(Name="Teacher Credit")]
        [Required(ErrorMessage = "Teacher credit is required")]
        public double TeacherCredit { get; set; }
        [ReadOnly(true)]
        [Display(Name="Remaining Credit")]
        [Required(ErrorMessage = "Remaining credit is required")]
        public double RemainingCredit { get; set; }
  
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Select a course")]
        public string CourseID { get; set; }
        [ReadOnly(true)]
       
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Name is required")]
        public string CourseName { get; set; }
         [Display(Name = "Course Credit")]
        [ReadOnly(true)]
        [Required(ErrorMessage = "Credit is required")]
        public double CourseCredit { get; set; }
        public bool Assign { get; set; }

    }
}