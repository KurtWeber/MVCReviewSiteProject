using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeReview.Models
{
    public class EmployeeReviewContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmployeeReviewContext() : base("name=EmployeeReviewContext")
        {
        }

        public System.Data.Entity.DbSet<EmployeeReview.Controllers.Title> Titles { get; set; }

        public System.Data.Entity.DbSet<EmployeeReview.Controllers.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<EmployeeReview.Controllers.EmployeeReview> EmployeeReviews { get; set; }
    }
}
