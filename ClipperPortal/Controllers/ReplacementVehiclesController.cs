using System;
using System.Web;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;
using System.Linq;

namespace ClipperPortal.Controllers
{
    public class ReplacementVehiclesController : Controller
    {
        // GET: ReplacementVehicles
        public ActionResult Index()
        {
            var model = ReplacementVehicleProvider.GetAll();
            //                var manufacturer = item.Manufacturer == "other" ? item.OtherManufacturer : item.Manufacturer;


            return View(model);
        }

        public ActionResult Grid()
        {
            return View();
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
                throw new Exception("testing");

                //ReplacementVehicleProvider.Update(id, data);
                //TempData["Message"] = statusMsg;
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = statusMsg + ex.ToString();
                return View();
            }
        }
    }
}