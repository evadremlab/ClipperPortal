using System;
using System.Web;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class ReplacementVehiclesController : Controller
    {
        // GET: ReplacementVehicles
        public ActionResult Index()
        {
            var model = ReplacementVehicleProvider.Get();

            return View(model);
        }

        // GET: ReplacementVehicles/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReplacementVehicles/Create
        [HttpPost]
        public ActionResult Create([System.Web.Http.FromBody]ReplacementVehicle data)
        {
            var statusMsg = "Created Replacement Vehicle";

            try
            {
                ReplacementVehicleProvider.Create(data);
                TempData["Message"] = statusMsg;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = statusMsg + ex.ToString();
                return View();
            }
        }

        // GET: ReplacementVehicles/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = ReplacementVehicleProvider.Get(id);

            return View(data);
        }

        // POST: ReplacementVehicles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [System.Web.Http.FromBody]ReplacementVehicle data)
        {
            var statusMsg = "Updated Replacement Vehicle ";

            try
            {
                ReplacementVehicleProvider.Update(id, data);
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