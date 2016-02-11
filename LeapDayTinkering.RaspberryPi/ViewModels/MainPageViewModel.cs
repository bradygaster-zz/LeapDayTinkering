using LeapDayTinkering.RaspberryPi.Http;
using System;

namespace LeapDayTinkering.RaspberryPi.ViewModels
{
    internal class MainPageViewModel
    {
        public string DeviceId { get; set; }
        public bool IsSending { get; set; }
        
        internal void SendSensorValue(string sensorName, double sensorValue)
        {
            LeapDayTinkeringAppService appServiceClient = new LeapDayTinkeringAppService();

            appServiceClient.Sensor.Post(new Models.SensorReading
            {
                DeviceId = this.DeviceId,
                SensorName = sensorName,
                Value = sensorValue
            });
        }
    }
}
