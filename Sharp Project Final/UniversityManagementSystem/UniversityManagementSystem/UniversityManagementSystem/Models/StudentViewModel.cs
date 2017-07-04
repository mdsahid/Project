using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Common;

namespace UniversityManagementSystem.Models
{
    [MetadataType(typeof(StudentViewModel))]
    public partial class Student
    {

    }
    public class StudentViewModel
    {
        public int studentID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name="Name")]
        public string studentName { get; set; }
         [Display(Name = "Email")]
        [RemoteClientServer("IsEmailExits", "Student", ErrorMessage = "Email is already exist")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string studentEmail { get; set; }
        [Required(ErrorMessage="Contact no is required")]
        [Display(Name = "Contact No")]
        public Nullable<long> studentContactNo { get; set; }
        [Required(ErrorMessage="Registration date is required")]
        [Display(Name = "Registration Date")]
        public Nullable<System.DateTime> regDate { get; set; }
        [Required(ErrorMessage="Address is required")]
        [Display(Name = "Address")]
        public string studentAddress { get; set; }
        [Required(ErrorMessage="Select a department")]
        [Display(Name = "Department")]
        public string depCode { get; set; }
      
        public string RegistrationNo { get; set; }
        //public decimal CurrentYear { get; set; }
        //[Required]
        //public string RegistrationNo { get; set; }
    }
}