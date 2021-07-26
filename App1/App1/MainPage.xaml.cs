using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            this.BindingContext = viewModel;
            InitializeComponent();

            client.BaseAddress = new Uri("http://192.168.1.125/apps/api/11/");

            getLightStatus();
        }

        private async void getLightStatus()
        {
            HttpResponseMessage response = await client.GetAsync("devices/7?access_token=c5cc9263-1fae-40bc-a860-dbf9f4fbed07");


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                MakerApiResponse makerApiResponse = JsonConvert.DeserializeObject<MakerApiResponse>(responseBody);

                string currentLightStatusString = (string)(makerApiResponse.attributes.FirstOrDefault(x => x.name == "switch")?.currentValue ?? "");

                viewModel.LightStatusOn = currentLightStatusString == "on" ? true : false;
            }
        }

        private async void OnOnClick(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("devices/7/on?access_token=c5cc9263-1fae-40bc-a860-dbf9f4fbed07");
            viewModel.LightStatusOn = true;
        }

        private async void OnOffClick(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("devices/7/off?access_token=c5cc9263-1fae-40bc-a860-dbf9f4fbed07");
            viewModel.LightStatusOn = false;
        }
    }
}
