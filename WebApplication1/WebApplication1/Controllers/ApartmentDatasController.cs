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
    public class ApartmentDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: ApartmentDatas
        public ActionResult Index()
        {
            return View(db.AppartmentDataModels.ToList());
        }

        // GET: ApartmentDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentData apartmentData = db.AppartmentDataModels.Find(id);
            if (apartmentData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentData);
        }

        // GET: ApartmentDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormHId,SizrId,FeatureId,AreaId,ApartImgId,BuildYear,Ytakvm,QuantityRooms,Floor,Price,Address,City,Region,PostalCode,Country,Available,RequiredDate,DisplayDate")] ApartmentData apartmentData)
        {
            if (ModelState.IsValid)
            {
                apartmentData.Id = Guid.NewGuid();
                db.AppartmentDataModels.Add(apartmentData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartmentData);
        }

        // GET: ApartmentDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentData apartmentData = db.AppartmentDataModels.Find(id);
            if (apartmentData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentData);
        }

        // POST: ApartmentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormHId,SizrId,FeatureId,AreaId,ApartImgId,BuildYear,Ytakvm,QuantityRooms,Floor,Price,Address,City,Region,PostalCode,Country,Available,RequiredDate,DisplayDate")] ApartmentData apartmentData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartmentData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartmentData);
        }

        // GET: ApartmentDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentData apartmentData = db.AppartmentDataModels.Find(id);
            if (apartmentData == null)
            {
                return HttpNotFound();
            }
            return View(apartmentData);
        }

        // POST: ApartmentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApartmentData apartmentData = db.AppartmentDataModels.Find(id);
            db.AppartmentDataModels.Remove(apartmentData);
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
