using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json.Linq;

namespace LeapDayTinkering.WebJob
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("incoming")] string message, TextWriter log)
        {
            JObject sensorReading = JObject.Parse(message);

            string deviceId = (string)sensorReading["DeviceId"];
            string sensorName = (string)sensorReading["SensorName"];
            double value = (double)sensorReading["Value"];

            log.WriteLine($"Received {value} from Sensor {sensorName} on device {deviceId}");
        }
    }
}
