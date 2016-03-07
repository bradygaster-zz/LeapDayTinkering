using System;

namespace LeapDayTinkering.RaspberryPi.ViewModels
{
    internal class MainPageViewModel
    {
        public string DeviceId { get; set; }
        public bool IsSending { get; set; }

        public MainPageViewModel()
        {
            IsSending = true;
        }

        internal void SendSensorValue(string sensorName, double sensorValue)
        {
            // change this URL to match your own App Service's root URL
            Uri baseUri = new Uri("http://appserviceasiotbackend.azurewebsites.net");
            LeapDayTinkeringAppService appServiceClient = new LeapDayTinkeringAppService(baseUri);

            appServiceClient.Sensor.Post(new Models.SensorReading
            {
                DeviceId = this.DeviceId,
                SensorName = sensorName,
                Value = sensorValue
            });
        }
    }
}



