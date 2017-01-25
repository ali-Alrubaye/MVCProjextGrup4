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
    public class ApartmentPhotoDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: ApartmentPhotoDatas
        public ActionResult Index()
        {
            return View(db.ApartmentPhotoDataModels.ToList());
        }

        // GET: ApartmentPhotoDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentPhotoData apartmentPhotoData = db.ApartmentPhotoDataModels.Find(id);
            if (apartmentPhotoData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentPhotoData);
        }

        // GET: ApartmentPhotoDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentPhotoDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Description,UpdataDate,Status,PhotoSize")] ApartmentPhotoData apartmentPhotoData)
        {
            if (ModelState.IsValid)
            {
                apartmentPhotoData.Id = Guid.NewGuid();
                db.ApartmentPhotoDataModels.Add(apartmentPhotoData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartmentPhotoData);
        }

        // GET: ApartmentPhotoDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentPhotoData apartmentPhotoData = db.ApartmentPhotoDataModels.Find(id);
            if (apartmentPhotoData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentPhotoData);
        }

        // POST: ApartmentPhotoDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Description,UpdataDate,Status,PhotoSize")] ApartmentPhotoData apartmentPhotoData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartmentPhotoData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartmentPhotoData);
        }

        // GET: ApartmentPhotoDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentPhotoData apartmentPhotoData = db.ApartmentPhotoDataModels.Find(id);
            if (apartmentPhotoData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentPhotoData);
        }

        // POST: ApartmentPhotoDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApartmentPhotoData apartmentPhotoData = db.ApartmentPhotoDataModels.Find(id);
            db.ApartmentPhotoDataModels.Remove(apartmentPhotoData);
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
