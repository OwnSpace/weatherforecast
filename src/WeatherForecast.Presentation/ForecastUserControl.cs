using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using WeatherForecast.Api.Resources.Responses;

namespace WeatherForecast.Presentation
{
    // note: это воркэраунд (форма, а не юзер контрол) из-за баги в визуальном отображении пользовательского контрола
    public partial class ForecastUserControl : Form
    {
        private DateTime date;
        private float minTemperature;
        private float maxTemperature;
        private float precipitation;
        private float wind;
        private string summary;
        private Image icon;

        public ForecastUserControl()
        {
            InitializeComponent();

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Visible = true;
        }

        [Category("Weather")]
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                lblDateValue.Text = date.ToString("dd MMMM");
            }
        }

        [Category("Weather")]
        public float MinTemperature
        {
            get => minTemperature;
            set
            {
                minTemperature = value;
                lblMin.Text = minTemperature.ToString();
            }
        }

        [Category("Weather")]
        public float MaxTemperature
        {
            get => maxTemperature;
            set
            {
                maxTemperature = value;
                lblMax.Text = maxTemperature.ToString();
            }
        }

        [Category("Weather")]
        public float Precipitation
        {
            get => precipitation;
            set
            {
                precipitation = value;
                lblPrecipitation.Text = precipitation.ToString();
            }
        }

        [Category("Weather")]
        public float Wind
        {
            get => wind;
            set
            {
                wind = value;
                lblWind.Text = wind.ToString();
            }
        }

        [Category("Weather")]
        public string Summary
        {
            get => summary;
            set
            {
                summary = value;
                lblSummary.Text = string.Join(",\n", summary.Split(","));
            }
        }

        [Category("Weather")]
        public Image WeatherIcon
        {
            get => icon;
            set
            {
                icon = value;
                pictureBox1.Image = icon;
            }
        }

        public static ForecastUserControl FromResponse(WeatherForecastResponse response)
        {
            return
                new ForecastUserControl
                    {
                        Date = response.Date,
                        MinTemperature = response.MinTemperatureC,
                        MaxTemperature = response.MaxTemperatureC,
                        Precipitation = response.Precipitation,
                        Wind = response.Wind,
                        Summary = response.Summary
                    };
        }
    }
}
