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
    public class OrderApartsController : Controller
    {
        private TestContext db = new TestContext();

        // GET: OrderAparts
        public ActionResult Index()
        {
            return View(db.OrderDataModels.ToList());
        }

        // GET: OrderAparts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderApart orderApart = db.OrderDataModels.Find(id);
            if (orderApart == null)
            {
                return HttpNotFound();
            }
            return View(orderApart);
        }

        // GET: OrderAparts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderAparts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UserId,OrderDate,RequiredDate,InFlytDate,Ytakvm,Price,OrderName,OrderAddress,OrderCity,OrderRegion,OrderPostalCode,OrderCountry,RowVersion")] OrderApart orderApart)
        {
            if (ModelState.IsValid)
            {
                orderApart.Id = Guid.NewGuid();
                db.OrderDataModels.Add(orderApart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderApart);
        }

        // GET: OrderAparts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderApart orderApart = db.OrderDataModels.Find(id);
            if (orderApart == null)
            {
                return HttpNotFound();
            }
            return View(orderApart);
        }

        // POST: OrderAparts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UserId,OrderDate,RequiredDate,InFlytDate,Ytakvm,Price,OrderName,OrderAddress,OrderCity,OrderRegion,OrderPostalCode,OrderCountry,RowVersion")] OrderApart orderApart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderApart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderApart);
        }

        // GET: OrderAparts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderApart orderApart = db.OrderDataModels.Find(id);
            if (orderApart == null)
            {
                return HttpNotFound();
            }
            return View(orderApart);
        }

        // POST: OrderAparts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OrderApart orderApart = db.OrderDataModels.Find(id);
            db.OrderDataModels.Remove(orderApart);
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
