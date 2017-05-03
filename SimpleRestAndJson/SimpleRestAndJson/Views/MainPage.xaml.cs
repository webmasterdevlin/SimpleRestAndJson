using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRestAndJson.ViewModels;
using Xamarin.Forms;

namespace SimpleRestAndJson
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;
        public MainPage()
        {
            vm = new MainPageViewModel();
            BindingContext = vm;

            InitializeComponent();
        }

        private async void Search_OnClicked(object sender, EventArgs e)
        {
            var longtitude = double.Parse(Lon.Text);
            var latitude = double.Parse(Lat.Text);

            var url = string.Format("http://api.geonames.org/findNearByWeatherJSON?lat={0}&lng={1}&username=webmasterdevlin", latitude, longtitude);
            await vm.GetWeatherAsync(url);
        }
    }
}