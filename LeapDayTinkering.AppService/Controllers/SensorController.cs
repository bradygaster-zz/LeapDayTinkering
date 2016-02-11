using LeapDayTinkering.AppService.Models;
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
    public class SensorController : ApiController
    {
        [ResponseType(typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "New registrations should pass Guid.Empty.", typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.Conflict, "The sensor ID has already been recorded.", typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.OK, "Sensor and/or Device recorded.", typeof(SensorReading))]
        public HttpResponseMessage Post(SensorReading sensorReading)
        {
            HttpResponseMessage ret = null;

            // has this device already been registered with this sensor name?
            if (DoesSensorAlreadyExist(sensorReading))
            {
                // return http conflict
                ret = Request.CreateResponse<SensorReading>(HttpStatusCode.Conflict, sensorReading);
            }
            else
            {
                // save the sensor reading
                SaveReading(sensorReading);
                ret = Request.CreateResponse<SensorReading>(HttpStatusCode.OK, sensorReading);
            }

            return ret;
        }

        private bool DoesSensorAlreadyExist(SensorReading sensorReading)
        {
            // todo: implement
            return false;
        }

        private bool SaveReading(SensorReading sensorReading)
        {
            // todo: implement
            return true;
        }
    }
}
