using Microsoft.Win32;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using weather.errorforms;
using weather.functions;

namespace weather.classes
{
    public class weatherclass
    {
        public string token;
        public string city;
        public string lang;
        public int time;
        public weatherclass()
        {
            



            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\my_weather_widget");
            if (key.GetValue("token") == null)
            {
                functions.functions.sendErrMessage();
                notoken form = new notoken();
                form.Show();
                
            }

            else
            {
                token = key.GetValue("token").ToString();
                city = key.GetValue("city").ToString();
                lang = key.GetValue("lang").ToString();
                time = (int)key.GetValue("time");
            }
        }

        public JSONNode getUpd()
        {
            string forecaststring = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={city}&lang={lang}&appid={token}");
            byte[] bytes = Encoding.Default.GetBytes(forecaststring);
            forecaststring = Encoding.UTF8.GetString(bytes);
            JSONNode forecast = JSON.Parse(forecaststring);

            return forecast;
        }

    }
}
