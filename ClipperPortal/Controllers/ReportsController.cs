using System;
using System.Text;
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

        // GET Report/ExportMatrix
        public FileContentResult ExportMatrix()
        {
            var csvExport = new CSVExporter();

            foreach (var reportMatrix in ReportProvider.GetMatrix())
            {
                csvExport.AddRow();

                foreach (var prop in reportMatrix.GetType().GetProperties())
                {
                    csvExport[prop.Name] = prop.GetValue(reportMatrix, null);
                }
            }

            return File(new UTF8Encoding().GetBytes(csvExport.Export()), "text/csv", "ReportMatrix.csv");
        }
    }
}
