using LeapDayTinkering.AppService.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System.Configuration;
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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager
                    .AppSettings["appserviceiotdata_AzureStorageConnectionString"]
                );

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("incoming");
            queue.CreateIfNotExists();

            string json = JsonConvert.SerializeObject(sensorReading);
            CloudQueueMessage message = new CloudQueueMessage(json);
            queue.AddMessage(message);

            return true;
        }
    }
}




