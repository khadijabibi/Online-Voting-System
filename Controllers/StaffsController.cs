using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EpicConstruction.Models.Data;
using EpicConstruction.ViewAdminModels;

namespace EpicConstruction.Controllers
{
    public class StaffsController : Controller
    {
        private DBAdminModel db = new DBAdminModel();

        // GET: Staffs
        public ActionResult Index()
        {
            return View(db.Staffs.ToList());
        }

        public ActionResult ReportView()
        {
            var Voted = db.Staffs.SqlQuery("SELECT * FROM dbo.Staffs Where Voting = 'Voted' ");            
            return View(Voted);
        }

        public ActionResult NotVotedReport()
        {
            var NotVoted = db.Staffs.SqlQuery("SELECT * FROM dbo.Staffs Where Voting = 'Not Voted' ");
            return View(NotVoted);
        }

        public ActionResult StaffVoteUpdate()
        {
            return View(db.Staffs.ToList());
        }

        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            if (staff.Voting == "Voted")
            {
                return RedirectToAction("Voted", "Home");
            }
            
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm([Bind(Include = "ID,FirstName,LastName,Department,Voting,VotedDate")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Voting = "Voted";
                staff.VotedDate = DateTime.Now;
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Voter", "Candidates");
                
            }
                   
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", staff.Department);
            return View(staff);


        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Department,Voting,VotedDate")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", staff.Department);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", staff.Department);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Department,Voting,VotedDate")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", staff.Department);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
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
