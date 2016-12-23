using System;
using System.Web.Mvc;

using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Report/Audit
        public ActionResult Audit()
        {
            var model = AuditRecordProvider.GetAll();

            return View(model);
        }

        // GET: Report/Matrix
        public ActionResult Matrix()
        {
            var model = ReportProvider.GetMatrix();

            return View(model);
        }
    }
}
