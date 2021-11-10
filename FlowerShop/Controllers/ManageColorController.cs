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
    public class ManageColorController : Controller
    {
        private asp11Entities db = new asp11Entities();

        // GET: ManageColor
        public ActionResult Index()
        {
            return View(db.COLORs.ToList());
        }

        // GET: ManageColor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLOR cOLOR = db.COLORs.Find(id);
            if (cOLOR == null)
            {
                return HttpNotFound();
            }
            return View(cOLOR);
        }

        // GET: ManageColor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageColor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COLOR_ID,COLOR_NAME")] COLOR cOLOR)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.COLORs.Add(cOLOR);
                db.SaveChanges();
                }
                catch (Exception)
                {
                }

                return RedirectToAction("Index");
            }

            return View(cOLOR);
        }

        // GET: ManageColor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLOR cOLOR = db.COLORs.Find(id);
            if (cOLOR == null)
            {
                return HttpNotFound();
            }
            return View(cOLOR);
        }

        // POST: ManageColor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COLOR_ID,COLOR_NAME")] COLOR cOLOR)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Entry(cOLOR).State = EntityState.Modified;
                db.SaveChanges();
                }
                catch (Exception)
                {

                }

                return RedirectToAction("Index");
            }
            return View(cOLOR);
        }

        // GET: ManageColor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLOR cOLOR = db.COLORs.Find(id);
            if (cOLOR == null)
            {
                return HttpNotFound();
            }
            return View(cOLOR);
        }

        // POST: ManageColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            COLOR cOLOR = db.COLORs.Find(id);
            db.COLORs.Remove(cOLOR);
            db.SaveChanges();
            }
            catch (Exception)
            {

            }

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
