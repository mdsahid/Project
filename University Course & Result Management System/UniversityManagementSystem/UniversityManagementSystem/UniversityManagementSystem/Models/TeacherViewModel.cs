using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UniversityManagementSystem.Common;
namespace UniversityManagementSystem.Models
{
    [MetadataType(typeof(TeacherViewModel))]
    public partial class Teacher
    {

    }
    public class TeacherViewModel
    {
        public int teacherID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string teacherName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string teacherAddress { get; set; }
        [RemoteClientServer("IsEmailExits", "Teacher", ErrorMessage = "Email is already exist")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string teacherEmail { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Credit must be a positive number")]
        [Display(Name = "Credit To Be Taken")]
        public Nullable<double> CreditToBeTaken { get; set; }
        [Required(ErrorMessage = "Contact no is required")]
        [Display(Name = "Contact No")]
        public Nullable<long> teacherContactNo { get; set; }
        [Display(Name = "Designation")]
        public Nullable<int> DesignationID { get; set; }
        [Display(Name = "Department")]
        public string depCode { get; set; }
    }
}