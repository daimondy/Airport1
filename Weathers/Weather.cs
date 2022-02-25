using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Weathers
{
    public enum Weather { Cloud, CloudSun, FlashCloud, 
        Hail, HardRain, LittleSnow, Rain, StormRain, Winds };
    

    public class WeatherForecast
    {
        private Random rnd;
        private Weather weather;

        public WeatherForecast()
        {
            rnd = new Random();
            SetRndWeatherOptions();
        }

        private void SetRndWeatherOptions()
        {
            int val = rnd.Next(0, 3);
            switch (val)
            {
                case 0:
                    weather = Weather.Cloud;
                    break;
                case 1:
                    weather = Weather.CloudSun;
                    break;
                case 2:
                    weather = Weather.FlashCloud;
                    break;
                case 3:
                    weather = Weather.Hail;
                    break;
                case 4:
                    weather = Weather.HardRain;
                    break;
                case 5:
                    weather = Weather.LittleSnow;
                    break;
                case 6:
                    weather = Weather.Rain;
                    break;
                case 7:
                    weather = Weather.StormRain;
                    break;
                case 8:
                    weather = Weather.Winds;
                    break;
            }
        }

        public Weather Weather { get => weather; set => weather = value; }
       
    }
}
