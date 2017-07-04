using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Common;

namespace UniversityManagementSystem.Models
{
    public class CourseStatics
    {      [Display(Name="Department")]
        public string depCode { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string SemesterName { get; set; }

        public string TeacherName { get; set; }

    }
}