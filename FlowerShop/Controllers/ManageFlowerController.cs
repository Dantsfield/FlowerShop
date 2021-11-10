using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class ManageFlowerController : Controller
    {
        private asp11Entities db = new asp11Entities();

        // GET: ManageFlower
        public ActionResult Index()
        {
            var fLOWERs = db.FLOWERs.Include(f => f.COLOR);
            return View(fLOWERs.ToList());
        }

        // GET: ManageFlower/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLOWER fLOWER = db.FLOWERs.Find(id);
            if (fLOWER == null)
            {
                return HttpNotFound();
            }
            return View(fLOWER);
        }

        // GET: ManageFlower/Create
        public ActionResult Create()
        {
            ViewBag.COLOR_ID = new SelectList(db.COLORs, "COLOR_ID", "COLOR_NAME");
            return View();
        }

        // POST: ManageFlower/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FLOWER_ID,FLOWER_NAME,COLOR_ID,FLOWER_SIZE,FLOWER_PRICE")] FLOWER fLOWER)
        {
            if (ModelState.IsValid)
            {

                try
                {
                db.FLOWERs.Add(fLOWER);
                db.SaveChanges();
                }
                catch (Exception)
                {

                }

                return RedirectToAction("Index");
            }

            ViewBag.COLOR_ID = new SelectList(db.COLORs, "COLOR_ID", "COLOR_NAME", fLOWER.COLOR_ID);
            return View(fLOWER);
        }

        // GET: ManageFlower/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLOWER fLOWER = db.FLOWERs.Find(id);
            if (fLOWER == null)
            {
                return HttpNotFound();
            }
            ViewBag.COLOR_ID = new SelectList(db.COLORs, "COLOR_ID", "COLOR_NAME", fLOWER.COLOR_ID);
            return View(fLOWER);
        }

        // POST: ManageFlower/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FLOWER_ID,FLOWER_NAME,COLOR_ID,FLOWER_SIZE,FLOWER_PRICE")] FLOWER fLOWER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fLOWER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COLOR_ID = new SelectList(db.COLORs, "COLOR_ID", "COLOR_NAME", fLOWER.COLOR_ID);
            return View(fLOWER);
        }

        // GET: ManageFlower/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLOWER fLOWER = db.FLOWERs.Find(id);
            if (fLOWER == null)
            {
                return HttpNotFound();
            }
            return View(fLOWER);
        }

        // POST: ManageFlower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FLOWER fLOWER = db.FLOWERs.Find(id);
            db.FLOWERs.Remove(fLOWER);
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
