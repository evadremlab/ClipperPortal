using System;
using System.Collections.Generic;
using System.Web.Http;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class ExpansionDetailsAPIController : ApiController
    {
        [HttpPost]
        public IEnumerable<ExpansionDetail> Get()
        {
            return ExpansionDetailProvider.GetAll();
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