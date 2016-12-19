using System;
using System.Web;
using System.Web.Mvc;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class ExpansionDetailsController : Controller
    {
        // GET: ExpansionDetails
        public ActionResult Index()
        {
            var model = ExpansionDetailProvider.Get();

            return View(model);
        }

        // GET: ExpansionDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpansionDetails/Create
        [HttpPost]
        public ActionResult Create([System.Web.Http.FromBody]ExpansionDetail data)
        {
            var statusMsg = "Created Replacement Vehicle";

            try
            {
                ExpansionDetailProvider.Create(data);
                TempData["Message"] = statusMsg;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = statusMsg + ex.ToString();
            }

            return RedirectToAction("Index");
        }

        // GET: ExpansionDetails/Edit/5
        public ActionResult Edit(int id)
        {
            var data = ExpansionDetailProvider.Get(id);

            return View(data);
        }

        // POST: ExpansionDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [System.Web.Http.FromBody]ExpansionDetail data)
        {
            var statusMsg = "Updated Replacement Vehicle ";

            try
            {
                ExpansionDetailProvider.Update(id, data);
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
