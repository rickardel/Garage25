using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoaGaraget.DataAccessLayer;
using GoaGaraget.Models;

namespace GoaGaraget.Controllers
{
    public class ParkingSpacesController : Controller
    {
        private GarageDbContext db = new GarageDbContext();

        // GET: ParkingSpaces
        public ActionResult Index()
        {
            var parkingSpaces = db.ParkingSpaces.Include(p => p.Garage);
            return View(parkingSpaces.ToList());
        }

        // GET: ParkingSpaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpace parkingSpace = db.ParkingSpaces.Find(id);
            if (parkingSpace == null)
            {
                return HttpNotFound();
            }
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Create
        public ActionResult Create()
        {
            ViewBag.GarageId = new SelectList(db.Garages, "Id", "Name");
            return View();
        }

        // POST: ParkingSpaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,IsEmpty,IsMcParkingSpace,TotalIncome,VisitorCount,AverageTime,McCountMax,GarageId")] ParkingSpace parkingSpace)
        {
            if (ModelState.IsValid)
            {
                db.ParkingSpaces.Add(parkingSpace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarageId = new SelectList(db.Garages, "Id", "Name", parkingSpace.GarageId);
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpace parkingSpace = db.ParkingSpaces.Find(id);
            if (parkingSpace == null)
            {
                return HttpNotFound();
            }
            ViewBag.GarageId = new SelectList(db.Garages, "Id", "Name", parkingSpace.GarageId);
            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,IsEmpty,IsMcParkingSpace,TotalIncome,VisitorCount,AverageTime,McCountMax,GarageId")] ParkingSpace parkingSpace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingSpace).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarageId = new SelectList(db.Garages, "Id", "Name", parkingSpace.GarageId);
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpace parkingSpace = db.ParkingSpaces.Find(id);
            if (parkingSpace == null)
            {
                return HttpNotFound();
            }
            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingSpace parkingSpace = db.ParkingSpaces.Find(id);
            db.ParkingSpaces.Remove(parkingSpace);
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
