using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeReview.Models;

namespace EmployeeReview.Controllers
{
    public class EmployeeReviewsController : Controller
    {
        private EmployeeReviewContext db = new EmployeeReviewContext();

        // GET: EmployeeReviews
        public ActionResult Index()
        {
            var employeeReviews = db.EmployeeReviews.Include(e => e.DepartmentName).Include(e => e.Title);
            return View(employeeReviews.ToList());
        }

        // GET: EmployeeReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReview employeeReview = db.EmployeeReviews.Find(id);
            if (employeeReview == null)
            {
                return HttpNotFound();
            }
            return View(employeeReview);
        }

        // GET: EmployeeReviews/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.TitleID = new SelectList(db.Titles, "Id", "TitleDept");
            return View();
        }

        // POST: EmployeeReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeName,DateOfHire,ReviewDate,Probation,Comments,TitleID,DepartmentID")] EmployeeReview employeeReview)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeReviews.Add(employeeReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employeeReview.DepartmentID);
            ViewBag.TitleID = new SelectList(db.Titles, "Id", "TitleDept", employeeReview.TitleID);
            return View(employeeReview);
        }

        // GET: EmployeeReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReview employeeReview = db.EmployeeReviews.Find(id);
            if (employeeReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employeeReview.DepartmentID);
            ViewBag.TitleID = new SelectList(db.Titles, "Id", "TitleDept", employeeReview.TitleID);
            return View(employeeReview);
        }

        // POST: EmployeeReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeName,DateOfHire,ReviewDate,Probation,Comments,TitleID,DepartmentID")] EmployeeReview employeeReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employeeReview.DepartmentID);
            ViewBag.TitleID = new SelectList(db.Titles, "Id", "TitleDept", employeeReview.TitleID);
            return View(employeeReview);
        }

        // GET: EmployeeReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReview employeeReview = db.EmployeeReviews.Find(id);
            if (employeeReview == null)
            {
                return HttpNotFound();
            }
            return View(employeeReview);
        }

        // POST: EmployeeReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeReview employeeReview = db.EmployeeReviews.Find(id);
            db.EmployeeReviews.Remove(employeeReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
