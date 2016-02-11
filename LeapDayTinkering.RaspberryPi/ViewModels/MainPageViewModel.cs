using LeapDayTinkering.RaspberryPi.Http;
using System;

namespace LeapDayTinkering.RaspberryPi.ViewModels
{
    internal class MainPageViewModel
    {
        const string API_URL = "https://leapday.azure-api.net";

        public string DeviceId { get; set; }
        public string SubscriberId { get; set; }
        public bool IsSending { get; set; }

        public MainPageViewModel()
        {
            this.SubscriberId = "[YOUR API MANAGEMENT SUBSCRIBER ID]";
        }

        internal void SendSensorValue(string sensorName, double sensorValue)
        {
            ApimRequestHandler delegatingHandler = 
                new ApimRequestHandler(this.SubscriberId);

            LeapDayTinkeringAppService appServiceClient = 
                new LeapDayTinkeringAppService(new Uri(API_URL), delegatingHandler);

            appServiceClient.Sensor.Post(new Models.SensorReading
            {
                DeviceId = this.DeviceId,
                SensorName = sensorName,
                Value = sensorValue
            });
        }
    }
}
