using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UniversityManagementSystem;
using UniversityManagementSystem.Common;
namespace UniversityManagementSystem.Models
{
    [MetadataType(typeof(DepartmentViewModel))]
    public partial class Department
    {

    }
    public class DepartmentViewModel
    {
        [Display(Name="Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department code must be between 2 to 7 characters")]
        [RemoteClientServer("IsCodeExits", "Department", ErrorMessage = "Code is already exist")]
        [Required(ErrorMessage = "Code is required")]
        public string depCode { get; set; }
        [RemoteClientServer("IsNameExits", "Department", ErrorMessage = "Name is already exist")]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name="Name")]
        public string depName { get; set; }

    }
}