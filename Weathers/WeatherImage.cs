using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airport.Weathers
{
    public class ImageController
    {
        WeatherForecast forecast;
        PictureBox pictureBox1;

        public ImageController(PictureBox pictureBox1, WeatherForecast forecast)
        {
            this.forecast = forecast;
            this.pictureBox1 = pictureBox1;
        }

        public void setWeather()
        {
            switch (forecast.Weather)
            {
                case Weather.Cloud:
                    pictureBox1.Image = Properties.Resources.cloud;
                    break;
                case Weather.CloudSun:
                    pictureBox1.Image = Properties.Resources.cloudsun;
                    break;
                case Weather.LittleSnow:
                    pictureBox1.Image = Properties.Resources.littlesnow;
                    break;
                case Weather.FlashCloud:
                    pictureBox1.Image = Properties.Resources.flashcloud;
                    break;
                case Weather.Hail:
                    pictureBox1.Image = Properties.Resources.hail;
                    break;
                case Weather.HardRain:
                    pictureBox1.Image = Properties.Resources.hardrain;
                    break;
                case Weather.StormRain:
                    pictureBox1.Image = Properties.Resources.stormrain;
                    break;
                case Weather.Winds:
                    pictureBox1.Image = Properties.Resources.snow;
                    break;

            }
        }
    }
}
