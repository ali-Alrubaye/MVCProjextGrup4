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
    public class FeaturesDatasController : Controller
    {
        private TestContext db = new TestContext();

        // GET: FeaturesDatas
        public ActionResult Index()
        {
            return View(db.FeatuersDataModels.ToList());
        }

        // GET: FeaturesDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturesData featuresData = db.FeatuersDataModels.Find(id);
            if (featuresData == null)
            {
                return HttpNotFound();
            }
            return View(featuresData);
        }

        // GET: FeaturesDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeaturesDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hiss,Balkog,Stadsnät,Tvättmaskin,Torltumlare,Diskmaskin,Comhem,Imd,Säkerhetsdörr")] FeaturesData featuresData)
        {
            if (ModelState.IsValid)
            {
                featuresData.Id = Guid.NewGuid();
                db.FeatuersDataModels.Add(featuresData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(featuresData);
        }

        // GET: FeaturesDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturesData featuresData = db.FeatuersDataModels.Find(id);
            if (featuresData == null)
            {
                return HttpNotFound();
            }
            return View(featuresData);
        }

        // POST: FeaturesDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hiss,Balkog,Stadsnät,Tvättmaskin,Torltumlare,Diskmaskin,Comhem,Imd,Säkerhetsdörr")] FeaturesData featuresData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featuresData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(featuresData);
        }

        // GET: FeaturesDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturesData featuresData = db.FeatuersDataModels.Find(id);
            if (featuresData == null)
            {
                return HttpNotFound();
            }
            return View(featuresData);
        }

        // POST: FeaturesDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FeaturesData featuresData = db.FeatuersDataModels.Find(id);
            db.FeatuersDataModels.Remove(featuresData);
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
