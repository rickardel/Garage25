using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoaGaraget.DataAccessLayer;
using GoaGaraget.Models;

namespace GoaGaraget.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageDbContext db = new GarageDbContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            return View(db.ParkedVehicles.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Statistics/5?
        public ActionResult Statistics(int? id)
        {
            if (id == null)
            {
                StatisticModel sm = new StatisticModel(db.ParkedVehicles.ToList());
                return PartialView("_Statistics", sm);
            }
            else
            {
                ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
                if (parkedVehicle != null)
                {
                    StatisticModel sm = new StatisticModel(parkedVehicle);
                    return View("Statistics", sm);
                }
            }
            return View("Index");
        }

        // GET: ParkedVehicles/Park/5
        public ActionResult Park(int? id)
        {

            if (id == null)
            {
                return View();
            }
            else
            {
                ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
                ParkingSpace[] parkingSpaces = db.ParkingSpaces.ToArray();
                ParkingModel pm = new ParkingModel(parkedVehicle, parkingSpaces);
                pm.ParkedVehicleId = (int)id;
                ViewBag.ParkingSpaceId = new SelectList(pm.AvailableParkingSpaces, "Id", "Id");
                //ViewBag.ParkedVehicleId = new SelectList(, "Id", "RegNumber", id);

                if (parkingSpaces[0] != null) pm.ParkingSpaceId = parkingSpaces[0].Id;

                if (parkedVehicle != null)
                {
                    return View(pm);
                }
            }
            return View("Index");
        }

        // POST : ParkedVehicles/Park/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "ParkedVehicleId, ParkingSpaceId")] ParkingModel parkingModel)
        {
            if (ModelState.IsValid)
            {
                ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(parkingModel.ParkedVehicleId);
                ParkingSpace parkingSpace;
                parkingModel.CreatedAt = DateTime.Now;
                int i = 0;
                do
                {
                    parkingSpace = db.ParkingSpaces.Find(parkingModel.ParkingSpaceId + i);
                    parkingSpace.IsEmpty = false;
                    parkedVehicle.ParkingSpaces.Add(parkingSpace);
                    db.Entry(parkingSpace).State = EntityState.Modified;
                    parkingSpace.ParkedVehicles.Add(parkedVehicle);
                    i++;
                } while (i < parkedVehicle.Size);
                parkedVehicle.CheckinDate = DateTime.Now;
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkingModel);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            Functionalities.DoIt doIt = new Functionalities.DoIt();
            //ViewBag.MemberId = new SelectList(db.Members, "Id", "PersonNumber");
            //ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name");

            ParkedVehicleViewModel pvvm = new ParkedVehicleViewModel();
            pvvm.Members = new SelectList(db.Members.ToList(), "Id", "PersonNumber");
            pvvm.VehicleTypes = new SelectList(db.VehicleTypes.ToList(), "Id", "Name");

            return View(pvvm);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,RegNumber,Color,VehicleTypeId,Brand,NumberOfWheels")] ParkedVehicleViewModel pvvm)
        {
            VehicleType vt = db.VehicleTypes.Single(v => v.Id == pvvm.VehicleTypeId);
            ParkedVehicle parkedVehicle = new ParkedVehicle(pvvm.MemberId, pvvm.RegNumber, pvvm.Color, vt, pvvm.Brand, pvvm.NumberOfWheels, DateTime.Now);
            parkedVehicle.Member = db.Members.Single(m => m.Id == pvvm.MemberId);
            parkedVehicle.VehicleType = vt;

            if (ModelState.IsValid)
            {
                parkedVehicle.Size = parkedVehicle.VehicleType.Size;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            pvvm.Members = new SelectList(db.Members.ToList(), "Id", "PersonNumber");
            pvvm.VehicleTypes = new SelectList(db.VehicleTypes.ToList(), "Id", "Name");
            return View(pvvm);
        }



        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ParkedVehicleInputModel parkedVehicleInput = new ParkedVehicleInputModel
            {
                Id = parkedVehicle.Id,
                RegNumber = parkedVehicle.RegNumber,
                Color = parkedVehicle.Color,
                Brand = parkedVehicle.Brand,
                NumberOfWheels = parkedVehicle.NumberOfWheels
            };
            return View(parkedVehicleInput);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Color,Type,Brand,NumberOfWheels,CheckinDate")] ParkedVehicleInputModel parkedVehicleInput)
        {
            if (ModelState.IsValid)
            {
                ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(parkedVehicleInput.Id);
                parkedVehicle.Id = parkedVehicleInput.Id;
                parkedVehicle.Color = parkedVehicleInput.Color;
                parkedVehicle.Brand = parkedVehicleInput.Brand;
                parkedVehicle.NumberOfWheels = parkedVehicleInput.NumberOfWheels;
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicleInput);
        }

        // GET: ParkedVehicles/Checkout/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            Receipt receipt = new Receipt(parkedVehicle);
            return View(receipt);
        }

        // POST: ParkedVehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutConfirmed(int id)
        {
            //ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            //db.ParkedVehicles.Remove(parkedVehicle);
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            Receipt receipt = new Receipt(parkedVehicle);
            foreach (var ps in parkedVehicle.ParkingSpaces)
            {
                ps.IsEmpty = true;

                ps.TotalIncome += receipt.Cost;
                ps.VisitorCount++ ;
                ps.AverageTime = 
                    TimeSpan.FromMinutes((int)Math
                    .Round(((ps.AverageTime+(receipt.CheckoutAt-receipt.CheckinAt))
                    .TotalMinutes)/ps.VisitorCount));
                //db.Entry(ps).State = EntityState.Modified;
            }
            parkedVehicle.ParkingSpaces.Clear();
            //db.Entry(parkedVehicle).State = EntityState.Modified;
            receipt.ParkedVehicle = parkedVehicle;
            receipt.ParkedVehicleId = parkedVehicle.Id;
            receipt.CheckoutAt = DateTime.Now;
            receipt.CheckinAt = parkedVehicle.CheckinDate;
            db.Receipts.Add(receipt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
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
