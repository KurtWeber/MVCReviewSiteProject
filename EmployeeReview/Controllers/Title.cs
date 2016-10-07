using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeReview.Controllers
{
    public class Title
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string TitleDept{ get; set; }
    }
}