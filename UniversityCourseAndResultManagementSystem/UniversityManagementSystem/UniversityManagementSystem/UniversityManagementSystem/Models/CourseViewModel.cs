using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Common;
namespace UniversityManagementSystem.Models
{
    [MetadataType(typeof(CourseViewModel))]
    public partial class Course
    {

    }
    public class CourseViewModel
    {
        public int courseId { get; set; }
        [Required(ErrorMessage = "Code is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Code must be at least 5 characters")]
        [RemoteClientServer("IsCodeExits", "Course", ErrorMessage = "Code is already exist")]
        [Display(Name="Code")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RemoteClientServer("IsNameExits", "Course", ErrorMessage = "Name is already exist")]
        [Display(Name = "Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be between 0.5 to 5")]
        [Display(Name = "Credit")]
        public Nullable<double> CourseCredit { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }
        [Display(Name="Department")]
        [Required(ErrorMessage = "Select a department")]
        public string depCode { get; set; }
         [Display(Name = "Semester")]
         [Required(ErrorMessage = "Select a semester")]
        public string SemesterID { get; set; }
    }
}