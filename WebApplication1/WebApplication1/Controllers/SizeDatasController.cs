using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SizeDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: SizeDatas
        public ActionResult Index()
        {
            return View(db.SizeDataModels.ToList());
        }

        // GET: SizeDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeData sizeData = db.SizeDataModels.Find(id);
            if (sizeData == null)
            {
                return HttpNotFound();
            }
            return View(sizeData);
        }

        // GET: SizeDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SizeId,SizekName,Description")] SizeData sizeData)
        {
            if (ModelState.IsValid)
            {
                sizeData.SizeId = Guid.NewGuid();
                db.SizeDataModels.Add(sizeData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizeData);
        }

        // GET: SizeDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeData sizeData = db.SizeDataModels.Find(id);
            if (sizeData == null)
            {
                return HttpNotFound();
            }
            return View(sizeData);
        }

        // POST: SizeDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SizeId,SizekName,Description")] SizeData sizeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizeData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizeData);
        }

        // GET: SizeDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeData sizeData = db.SizeDataModels.Find(id);
            if (sizeData == null)
            {
                return HttpNotFound();
            }
            return View(sizeData);
        }

        // POST: SizeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SizeData sizeData = db.SizeDataModels.Find(id);
            db.SizeDataModels.Remove(sizeData);
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
