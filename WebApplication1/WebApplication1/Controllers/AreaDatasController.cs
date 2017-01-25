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
    public class AreaDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: AreaDatas
        public ActionResult Index()
        {
            return View(db.AreaDataModels.ToList());
        }

        // GET: AreaDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaData areaData = db.AreaDataModels.Find(id);
            if (areaData == null)
            {
                return HttpNotFound();
            }
            return View(areaData);
        }

        // GET: AreaDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaName,ImageUrl,Description")] AreaData areaData)
        {
            if (ModelState.IsValid)
            {
                areaData.Id = Guid.NewGuid();
                db.AreaDataModels.Add(areaData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaData);
        }

        // GET: AreaDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaData areaData = db.AreaDataModels.Find(id);
            if (areaData == null)
            {
                return HttpNotFound();
            }
            return View(areaData);
        }

        // POST: AreaDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaName,ImageUrl,Description")] AreaData areaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaData);
        }

        // GET: AreaDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaData areaData = db.AreaDataModels.Find(id);
            if (areaData == null)
            {
                return HttpNotFound();
            }
            return View(areaData);
        }

        // POST: AreaDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AreaData areaData = db.AreaDataModels.Find(id);
            db.AreaDataModels.Remove(areaData);
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
