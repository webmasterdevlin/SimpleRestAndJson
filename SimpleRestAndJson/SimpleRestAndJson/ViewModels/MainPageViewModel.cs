using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SimpleRestAndJson.Annotations;
using SimpleRestAndJson.Models;

namespace SimpleRestAndJson.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _station;

        public string Station
        {
            get { return _station; }
            set
            {
                _station = value;
                OnPropertyChanged();
            }
        }

        private long _elevation;

        public long Elevation
        {
            get { return _elevation; }
            set
            {
                _elevation = value;
                OnPropertyChanged();
            }
        }

        private long _temp;

        public long Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged();
            }
        }

        private long _humidity;

        public long Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task GetWeatherAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var JsonResult = response.Content.ReadAsStringAsync().Result;
            var weather = JsonConvert.DeserializeObject<WeatherResult>(JsonResult);
            SetValues(weather);
        }

        private void SetValues(WeatherResult weather)
        {
            var stationName = weather.weatherObservation.stationName;
            var elevation = weather.weatherObservation.elevation;
            var temperature = weather.weatherObservation.temperature;
            var humidity = weather.weatherObservation.humidity;

            Station = stationName;
            Elevation = elevation;
            Temp = temperature;
            Humidity = humidity;
        }




    }
}