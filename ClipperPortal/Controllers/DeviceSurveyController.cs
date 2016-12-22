using System;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class DeviceSurveyController : Controller
    {
        // GET: DeviceSurvey
        public ActionResult Index()
        {
            var model = DeviceSurveyProvider.GetAll();

            return View(model);
        }

        // GET: ExpansionDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new DeviceSurvey();

            return View(model);
        }

        // POST: ExpansionDDeviceSurveyetails/Create
        [HttpPost]
        public ActionResult Create([System.Web.Http.FromBody]DeviceSurvey data)
        {
            var statusMsg = "Created Replacement Vehicle";

            try
            {
                DeviceSurveyProvider.Create(data);
                TempData["Message"] = statusMsg;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = statusMsg + ex.ToString();
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: DeviceSurvey/Edit/5
        public ActionResult Edit(int id)
        {
            var data = DeviceSurveyProvider.Get(id);

            return View(data);
        }

        // POST: DeviceSurvey/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [System.Web.Http.FromBody]DeviceSurvey data)
        {
            var statusMsg = "Updated Device Survey";

            try
            {
                DeviceSurveyProvider.Update(id, data);
                TempData["Message"] = statusMsg;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = statusMsg + ex.ToString();
                return View();
            }
        }
    }
}
