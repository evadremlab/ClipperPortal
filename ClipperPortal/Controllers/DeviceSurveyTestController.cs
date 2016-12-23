using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ClipperPortal.Models;

namespace ClipperPortal.Controllers
{
    public class DeviceSurveyTestController : Controller
    {
        private ClipperContext db = new ClipperContext();

        // GET: DeviceSurveyTest
        public ActionResult Index()
        {
            return View(db.DeviceSurveys.ToList());
        }

        // GET: DeviceSurveyTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceSurveyTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalendarYear,Agency,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,FlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus")] DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                db.DeviceSurveys.Add(deviceSurvey);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }

        // GET: DeviceSurveyTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DeviceSurvey deviceSurvey = db.DeviceSurveys.Find(id);

            if (deviceSurvey == null)
            {
                return HttpNotFound();
            }

            return View(deviceSurvey);
        }

        // POST: DeviceSurveyTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CalendarYear,Agency,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,FlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus")] DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceSurvey).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }

        //// GET: DeviceSurveyTest/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    DeviceSurvey deviceSurvey = db.DeviceSurveys.Find(id);

        //    if (deviceSurvey == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(deviceSurvey);
        //}

        //// POST: DeviceSurveyTest/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    DeviceSurvey deviceSurvey = db.DeviceSurveys.Find(id);
        //    db.DeviceSurveys.Remove(deviceSurvey);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

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
