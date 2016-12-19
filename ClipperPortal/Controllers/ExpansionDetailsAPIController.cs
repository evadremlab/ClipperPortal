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
    public class ExpansionDetailsAPIController : ApiController
    {
        public IEnumerable<ExpansionDetail> Get()
        {
            return ExpansionDetailProvider.Get();
        }

        public ExpansionDetail Get(int id)
        {
            return ExpansionDetailProvider.Get(id);
        }

        public APIResponse Post(ExpansionDetail data)
        {
            ExpansionDetailProvider.Create(data);
            return new APIResponse { Status = "Expansion Detail Created" };
        }

        public APIResponse Put(int id, [FromBody]ExpansionDetail data)
        {
            ExpansionDetailProvider.Update(id, data);
            return new APIResponse { Status = "Expansion Detail Updated" };
        }

        public APIResponse Delete(int id)
        {
            ExpansionDetailProvider.Delete(id);
            return new APIResponse { Status = "Expansion Detail Deleted" };
        }
    }
}