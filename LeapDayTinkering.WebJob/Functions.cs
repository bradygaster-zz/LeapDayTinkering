using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace LeapDayTinkering.WebJob
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("incoming")] string message, 
            [Table("sensorreadings")] ICollector<SensorReading> tableBinding,
            TextWriter log)
        {
            JObject sensorReading = JObject.Parse(message);

            string deviceId = (string)sensorReading["DeviceId"];
            string sensorName = (string)sensorReading["SensorName"];
            double value = (double)sensorReading["Value"];

            var tableEntity = new SensorReading
            {
                DeviceId = deviceId,
                PartitionKey = "Test",
                SensorName = sensorName,
                Timestamp = DateTime.Now,
                Value = value,
                RowKey = Guid.NewGuid().ToString()
            };

            tableBinding.Add(tableEntity);

            log.WriteLine($"Received {value} from Sensor {sensorName} on device {deviceId}");
        }
    }

    public class SensorReading : TableEntity
    {
        public string DeviceId { get; set; }
        public string SensorName { get; set; }
        public double Value { get; set; }
    }
}
