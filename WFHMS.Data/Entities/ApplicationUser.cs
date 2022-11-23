using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHMS.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Department department { get; set; }
        [Required]
        public int departmentId { get; set; }
        public string DepartmentName{get;set; }

        public Designation designation { get; set; }
        [Required]
        public int designationId { get; set; }
        public string DesignationName{get;set; }

        public virtual IEnumerable<Department> Departments { get; set; }


        public virtual ICollection<ApplyForWFH> ApplyForWFHs { get; set; }

      
    }
}
