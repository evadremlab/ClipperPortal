using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.IO;

namespace ClipperPortal.Controllers
{
    public class DeviceSurveyController : Controller
    {
        // GET: DeviceSurvey
        public ActionResult Index()
        {
            var model = DeviceSurveyProvider.GetList();

            return View(model);
        }

        // GET: DeviceSurvey/Create
        public ActionResult Create()
        {
            return View(new DeviceSurvey());
        }

        // POST: DeviceSurvey/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,ReportingPeriod,Operator,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,NewFlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus,Notes")] DeviceSurvey deviceSurvey)
        public ActionResult Create(DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                DeviceSurveyProvider.Create(deviceSurvey);

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }

        // GET: DeviceSurvey/Edit/5
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

        // POST: DeviceSurvey/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,ReportingPeriod,Operator,UserName,Email,IsExpectingNewVehicles,HasGillig,HasNewFlyer,HasElDorado,HasOther,OtherName,GilligNewVehicles,GilligNewModel,GilligReplacementVehicles,GilligReplacementManufacturingDate,GilligReplacementDeliveryDate,GilligExpansionVehicles,GilligExpansionManufacturingDate,GilligExpansionDeliveryDate,NewFlyerNewVehicles,NewFlyerNewModel,NewFlyerReplacementVehicles,NewFlyerReplacementManufacturingDate,NewFlyerReplacementDeliveryDate,NewFlyerExpansionVehicles,NewFlyerExpansionManufacturingDate,NewFlyerExpansionDeliveryDate,ElDoradoNewVehicles,ElDoradoNewModel,ElDoradoReplacementVehicles,ElDoradoReplacementManufacturingDate,ElDoradoReplacementDeliveryDate,ElDoradoExpansionVehicles,ElDoradoExpansionManufacturingDate,ElDoradoExpansionDeliveryDate,OtherNewVehicles,OtherNewModel,OtherReplacementVehicles,OtherReplacementManufacturingDate,OtherReplacementDeliveryDate,OtherExpansionVehicles,OtherExpansionManufacturingDate,OtherExpansionDeliveryDate,OwnExistingVehicles,ExistingVehicleDetails,ReplacementVehicleDetails,PreWireRequirements,IncludedCosts,LastUpdated,RecordStatus,Notes")] DeviceSurvey deviceSurvey)
        public ActionResult Edit(DeviceSurvey deviceSurvey)
        {
            if (ModelState.IsValid)
            {
                DeviceSurveyProvider.Update(deviceSurvey);

                return RedirectToAction("Index");
            }

            return View(deviceSurvey);
        }

        // GET DeviceSurvey/Export
        public FileContentResult Export()
        {
            var csvExport = new CSVExporter();
            var excludedFields = "ID,HasGilligYN,HasNewFlyerYN,HasElDoradoYN,HasOtherYN,IsGilligNewVehiclesAndModelRequired,IsNewFlyerNewVehiclesAndModelRequired,IsElDoradoNewVehiclesAndModelRequired,IsOtherNewVehiclesAndModelRequired";
            var excluded = excludedFields.Split(',').ToList<String>();

            foreach (var deviceSurvey in DeviceSurveyProvider.GetAll())
            {
                csvExport.AddRow();

                foreach (var prop in deviceSurvey.GetType().GetProperties())
                {
                    if (excluded.Find(x => x == prop.Name) == null)
                    {
                        csvExport[prop.Name] = prop.GetValue(deviceSurvey, null);
                    }
                }
            }

            return File(new UTF8Encoding().GetBytes(csvExport.Export()), "text/csv", "DeviceSurvey.csv");
        }
    }
}
