using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class DeviceSurveyController : Controller
    {
        // GET: DeviceSurveyTest
        public ActionResult Index()
        {
            return View(DeviceSurveyProvider.GetAll());
        }

        // GET: DeviceSurveyTest/Create
        public ActionResult Create()
        {
            return View(new DeviceSurvey());
        }

        // POST: DeviceSurveyTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalendarYear,Agency,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,NewFlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus")] DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                DeviceSurveyProvider.Create(deviceSurvey);

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }

        // GET: DeviceSurveyTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var deviceSurvey = DeviceSurveyProvider.Get(id.Value);

            if (deviceSurvey == null)
            {
                return HttpNotFound();
            }

            return View(deviceSurvey);
        }

        // POST: DeviceSurveyTest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CalendarYear,Agency,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,NewFlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus")] DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                DeviceSurveyProvider.Update(deviceSurvey);

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }
    }
}
