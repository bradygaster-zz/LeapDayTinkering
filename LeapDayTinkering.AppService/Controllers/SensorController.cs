using LeapDayTinkering.AppService.Models;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LeapDayTinkering.AppService.Controllers
{
    public class SensorController : ApiController
    {
        [ResponseType(typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Unknown device.", typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.OK, "Sensor value recorded.", typeof(SensorReading))]
        public HttpResponseMessage Post(SensorReading sensorReading)
        {
            if (!DoesDeviceAlreadyExist(sensorReading.DeviceId))
            {
                return Request.CreateResponse<SensorReading>(HttpStatusCode.NotFound, sensorReading);
            }

            SaveReading(sensorReading);

            return Request.CreateResponse<SensorReading>(HttpStatusCode.OK, sensorReading);
        }

        private bool DoesDeviceAlreadyExist(string deviceId)
        {
            // todo: implement
            return true;
        }

        private bool SaveReading(SensorReading sensorReading)
        {
            // todo: implement
            return true;
        }
    }
}




