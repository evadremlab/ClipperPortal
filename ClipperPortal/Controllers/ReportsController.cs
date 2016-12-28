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

        // GET Report/ExportAudit
        public FileContentResult ExportAudit()
        {
            string displayName;
            var csvExport = new CSVExporter();

            foreach (var auditRecord in AuditRecordProvider.GetAll())
            {
                csvExport.AddRow();

                foreach (var prop in auditRecord.GetType().GetProperties())
                {
                    switch (prop.Name) {
                        case "EntityName":
                            displayName = "Entity";
                            break;
                        case "PrimaryKeyValue":
                            displayName = "ID";
                            break;
                        case "PropertyName":
                            displayName = "Property";
                            break;
                        case "OldValue":
                            displayName = "Old Value";
                            break;
                        case "NewValue":
                            displayName = "New Value";
                            break;
                        case "DateChanged":
                            displayName = "Date Changed";
                            break;
                        case "UserName":
                            displayName = "Changed By";
                            break;
                        default:
                            displayName = prop.Name;
                            break;
                    }

                    csvExport[displayName] = prop.GetValue(auditRecord, null);
                }
            }

            return File(new UTF8Encoding().GetBytes(csvExport.Export()), "text/csv", "AuditRecords.csv");
        }

        // GET Report/ExportMatrix
        public FileContentResult ExportMatrix()
        {
            string displayName;
            var csvExport = new CSVExporter();

            foreach (var reportMatrix in ReportProvider.GetMatrix())
            {
                csvExport.AddRow();

                foreach (var prop in reportMatrix.GetType().GetProperties())
                {
                    switch (prop.Name)
                    {
                        case "CalendarYear":
                            displayName = "Calendar Year";
                            break;
                        case "Agency":
                            displayName = "Operator";
                            break;
                        case "RecordStatus":
                            displayName = "Record Status";
                            break;
                        case "NewVehicles":
                            displayName = "New Vehicles";
                            break;
                        case "ExpansionVehicles":
                            displayName = "Expansion Vehicles";
                            break;
                        case "ReplacementVehicles":
                            displayName = "Replacement Vehicles";
                            break;
                        default:
                            displayName = prop.Name;
                            break;
                    }

                    csvExport[displayName] = prop.GetValue(reportMatrix, null);
                }
            }

            return File(new UTF8Encoding().GetBytes(csvExport.Export()), "text/csv", "ReportMatrix.csv");
        }
    }
}
