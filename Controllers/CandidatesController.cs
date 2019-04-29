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
    public class CandidatesController : Controller
    {
        private DBAdminModel db = new DBAdminModel();
        

        //// GET: Candidates
        public ActionResult Index()
        {
            var candidates = db.Candidates.Include(c => c.Staff);
            return View(candidates.ToList());
        }

        public ActionResult DetailCandidateList()
        {
            var candidates = db.Candidates.Include(c => c.Staff);
            return View(candidates.ToList());
        }
        public ActionResult Voter()
        {
            var candidates = db.Candidates.Include(c => c.Staff);
            return View(candidates.ToList());
        }
                
        public ActionResult Vote(int? id)
        {
            //Looking for candidate id in candidate database
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);            
            if (candidate == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.StaffID = new SelectList(db.Staffs, "ID", "ID", candidate.StaffID);           

            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote([Bind(Include = "ID,StaffID,FirstName,LastName,Department,Votes")] Candidate candidate)
        {
            
                if (ModelState.IsValid)
                {
                        candidate.Votes++;                        
                        db.Entry(candidate).State = EntityState.Modified;                        
                        db.SaveChanges();
                        return RedirectToAction("Thankyou", "Home");         
                
                }
            
                return View(candidate);
        }

        public ActionResult VotingStatistic()
        {
            ViewBag.Total = db.Staffs.SqlQuery("SELECT * FROM dbo.Staffs ").Count();
            ViewBag.Voted = db.Staffs.SqlQuery("SELECT * FROM dbo.Staffs Where Voting = 'Voted' ").Count();            
            
            ViewBag.Percent = ((ViewBag.Voted / ViewBag.Total) * 100);

            return View(db.Candidates.ToList());
            

            
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.Staffs, "ID", "ID");
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StaffID,FirstName,LastName,Department,Votes")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.Staffs, "ID", "ID" , candidate.StaffID);
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", candidate.Department);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.Staffs, "ID", "ID", candidate.StaffID);
            ViewBag.Department = new SelectList(db.Departments, "DeptName", "DeptName", candidate.Department);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StaffID,FirstName,LastName,Department,Votes")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.Staffs, "ID", "ID", candidate.StaffID);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
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
