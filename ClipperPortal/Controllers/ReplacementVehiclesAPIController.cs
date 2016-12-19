using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using MySql.Data;
using MySql.Data.MySqlClient;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class ReplacementVehiclesAPIController : ApiController
    {
        public IEnumerable<ReplacementVehicle> Get()
        {
            return ReplacementVehicleProvider.Get();
        }

        public ReplacementVehicle Get(int id)
        {
            return ReplacementVehicleProvider.Get(id);
        }

        public APIResponse Post(ReplacementVehicle data)
        {
            ReplacementVehicleProvider.Create(data);
            return new APIResponse { Status = "Replacement Vechicle Created" };
        }

        public APIResponse Put(int id, [FromBody]ReplacementVehicle data)
        {
            ReplacementVehicleProvider.Update(id, data);
            return new APIResponse { Status = "Replacement Vechicle Updated" };
        }

        public APIResponse Delete(int id)
        {
            ReplacementVehicleProvider.Delete(id);
            return new APIResponse { Status = "Replacement Vechicle Deleted" };
        }
    }
}