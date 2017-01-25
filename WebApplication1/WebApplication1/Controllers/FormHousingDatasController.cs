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
    public class FormHousingDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: FormHousingDatas
        public ActionResult Index()
        {
            return View(db.FormHousingDataModels.ToList());
        }

        // GET: FormHousingDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormHousingData formHousingData = db.FormHousingDataModels.Find(id);
            if (formHousingData == null)
            {
                return HttpNotFound();
            }
            return View(formHousingData);
        }

        // GET: FormHousingDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormHousingDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormOfHousing,Description")] FormHousingData formHousingData)
        {
            if (ModelState.IsValid)
            {
                formHousingData.Id = Guid.NewGuid();
                db.FormHousingDataModels.Add(formHousingData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formHousingData);
        }

        // GET: FormHousingDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormHousingData formHousingData = db.FormHousingDataModels.Find(id);
            if (formHousingData == null)
            {
                return HttpNotFound();
            }
            return View(formHousingData);
        }

        // POST: FormHousingDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormOfHousing,Description")] FormHousingData formHousingData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formHousingData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formHousingData);
        }

        // GET: FormHousingDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormHousingData formHousingData = db.FormHousingDataModels.Find(id);
            if (formHousingData == null)
            {
                return HttpNotFound();
            }
            return View(formHousingData);
        }

        // POST: FormHousingDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FormHousingData formHousingData = db.FormHousingDataModels.Find(id);
            db.FormHousingDataModels.Remove(formHousingData);
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
