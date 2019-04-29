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
    public class VotingDateRestrictionsController : Controller
    {
        private DBAdminModel db = new DBAdminModel();

        // GET: VotingDateRestrictions
        public ActionResult Index()
        {
            return View(db.VotingDateRestrictions.ToList());
        }

        // GET: VotingDateRestrictions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingDateRestriction votingDateRestriction = db.VotingDateRestrictions.Find(id);
            if (votingDateRestriction == null)
            {
                return HttpNotFound();
            }
            return View(votingDateRestriction);
        }

        // GET: VotingDateRestrictions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VotingDateRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartVoting,EndVoting")] VotingDateRestriction votingDateRestriction)
        {
            if (ModelState.IsValid)
            {
                db.VotingDateRestrictions.Add(votingDateRestriction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(votingDateRestriction);
        }

        // GET: VotingDateRestrictions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingDateRestriction votingDateRestriction = db.VotingDateRestrictions.Find(id);
            if (votingDateRestriction == null)
            {
                return HttpNotFound();
            }
            return View(votingDateRestriction);
        }

        // POST: VotingDateRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StartVoting,EndVoting")] VotingDateRestriction votingDateRestriction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votingDateRestriction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(votingDateRestriction);
        }

        // GET: VotingDateRestrictions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingDateRestriction votingDateRestriction = db.VotingDateRestrictions.Find(id);
            if (votingDateRestriction == null)
            {
                return HttpNotFound();
            }
            return View(votingDateRestriction);
        }

        // POST: VotingDateRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VotingDateRestriction votingDateRestriction = db.VotingDateRestrictions.Find(id);
            db.VotingDateRestrictions.Remove(votingDateRestriction);
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
