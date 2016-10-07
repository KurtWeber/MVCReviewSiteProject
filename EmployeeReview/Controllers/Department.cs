using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeReview.Controllers
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
    }
}