using System;
using System.Collections.Generic;
using System.Web.Http;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class DeviceSurveyAPIController : ApiController
    {
        [HttpGet]
        public IEnumerable<DeviceSurvey> Get()
        {
            return DeviceSurveyProvider.GetAll();
        }

        [HttpGet]
        public DeviceSurvey Get(int id)
        {
            return DeviceSurveyProvider.Get(id);
        }

        [HttpDelete]
        public APIResponse Delete(int id)
        {
            try
            {
                DeviceSurveyProvider.Delete(id);

                return new APIResponse { Status = "Device Survey Deleted" };
            }
            catch (Exception ex)
            {
                return new APIResponse { ErrorMessage = ex.Message };
            }
        }
    }
}
