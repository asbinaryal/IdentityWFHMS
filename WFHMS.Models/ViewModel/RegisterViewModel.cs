using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Models.ViewModel
{
    public class RegisterViewModel
    {
      
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm-Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation Password donot Match")]
        public string ConfirmPassword { get; set; }

        public string DepartmentName { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public string? DesignationName { get; set; }
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        public IEnumerable<SelectListItem> Designations { get; set; }

     

    }
}