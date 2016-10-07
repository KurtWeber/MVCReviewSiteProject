using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReview.Controllers
{
    public class EmployeeReview
    {
        // Employee review controller
        [Key]
        public int ID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }
        [Display(Name = "Date of hire")]
        public DateTime DateOfHire { get; set; }
        [Display(Name = "Date of review")]
        public DateTime ReviewDate { get; set; }
        public bool Probation { get; set; }
        public string Comments { get; set; }

        [Display(Name = "Title")]
        [ForeignKey("Title")]
        public int TitleID { get; set; }
        public virtual Title Title { get; set; }

        [ForeignKey("DepartmentName")]
        public int DepartmentID { get; set; }
        public virtual Department DepartmentName{ get; set; }
        
    }
}