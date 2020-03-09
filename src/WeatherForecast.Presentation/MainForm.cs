using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using WeatherForecast.Api.Resources.Responses;

namespace WeatherForecast.Presentation
{
    public partial class MainForm : Form
    {
        public MainForm(IEnumerable<CityResponse> cities)
        {
            InitializeComponent();

            cmbCities.DataSource = cities.ToArray();
            cmbCities.DisplayMember = nameof(CityResponse.Name);
            cmbCities.ValueMember = nameof(CityResponse.Id);
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            var date = dtpDate.Value;
            var cityId = (Guid)cmbCities.SelectedValue;
            var forecasts = (await WeatherForecastAgent.GetWeatherForecasts(date, cityId)).ToArray();

            pnlForecasts.Controls.Clear();

            // ReSharper disable once CoVariantArrayConversion
            pnlForecasts.Controls.AddRange(forecasts.Select(ForecastUserControl.FromResponse).ToArray());
        }
    }
}
