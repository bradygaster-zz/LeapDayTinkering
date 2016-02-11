using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LeapDayTinkering.AppService.Controllers
{
    public class DeviceController : ApiController
    {
        [ResponseType(typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Conflict, "A device with this ID has already been recorded.", typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Created, "The device ID was recorded successfully.", typeof(bool))]
        public HttpResponseMessage Post(string deviceId)
        {
            if(DoesDeviceAlreadyExist(deviceId))
            {
                return Request.CreateResponse<bool>(HttpStatusCode.Conflict, false);
            }
            else
            {
                return Request.CreateResponse<bool>(HttpStatusCode.Created, true);
            }
        }

        private bool DoesDeviceAlreadyExist(string deviceId)
        {
            // todo: implement
            return false;
        }
    }
}
