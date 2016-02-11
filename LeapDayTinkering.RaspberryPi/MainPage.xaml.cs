using LeapDayTinkering.RaspberryPi.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Windows.UI.Xaml.Controls;

namespace LeapDayTinkering.RaspberryPi
{
    public sealed partial class MainPage : Page
    {
        Timer _timer;

        private MainPageViewModel ViewModel
        {
            get { return DataContext as MainPageViewModel; }
            set { DataContext = value; }
        }

        public MainPage()
        {
            this.ViewModel = new MainPageViewModel();

            this.ViewModel.DeviceId = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles().First().NetworkAdapter.NetworkAdapterId.ToString();

            this.InitializeComponent();

            _timer = new Timer(new TimerCallback((x) =>
            {
                MainPageViewModel viewModel = ((MainPageViewModel)x);

                if (viewModel.IsSending)
                {
                    viewModel.SendSensorValue("MockSensor", 3.14);
                }
            }), this.ViewModel, 1000, 20000);
        }
    }
}