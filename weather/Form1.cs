using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using weather.errorforms;
using System.Net;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace weather
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showCmds);


        public Form1()
        {
            InitializeComponent();
        }



        async void Form1_Load(object sender, EventArgs e)
        {
          

            ShowWindow(this.Handle, 0);
            notifyIcon1.Visible = true;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\my_weather_widget");
            if (key.GetValue("token")==null)
            {
                notoken form = new notoken();
                form.Show();
            }

            else {
                string token = key.GetValue("token").ToString();
                string city=key.GetValue("city").ToString();
                string lang = key.GetValue("lang").ToString();
                int time=(int)key.GetValue("time");





               while (true)
                {
                    try
                    {

                    string forecaststring = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={city}&lang={lang}&appid={token}");
                    byte[] bytes = Encoding.Default.GetBytes(forecaststring);
                    forecaststring = Encoding.UTF8.GetString(bytes);
                    JSONNode forecast = JSON.Parse(forecaststring);

                    var sky = forecast["weather"][0]["description"];
                   
                    



                    ToastContentBuilder toastContentBuilder = new ToastContentBuilder();
                    toastContentBuilder.AddText($"{forecast["weather"][0]["description"]}\n Температура: {Math.Round( forecast["main"]["temp"] - 273.15, 3)} \n Ощущается как: {Math.Round( forecast["main"]["feels_like"] - 273.15, 3)} \nДавление: {forecast["main"]["pressure"]}\nСкорость ветра {forecast["wind"]["speed"]}");
                    toastContentBuilder.Show();
                    await Task.Delay(time);

                    }
                    catch
                    {
                        ToastContentBuilder toastContentBuilder = new ToastContentBuilder();
                        toastContentBuilder.AddText($"Произошёл какой-то пиздец. Скорее всего неверный токен. Открываю окно настроек...");
                        toastContentBuilder.Show();

                        Form form = new notoken();
                        form.Show();
                        await Task.Delay(60000000);
                        //throw;

                    }
                    
                }

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState=FormWindowState.Normal;
            
            ShowWindow(this.Handle, 1);
            this.Activate();
            notifyIcon1.Visible = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настроитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notoken form = new notoken();
            form.Show();
        }

        void Form1_Deactivate(object sender, EventArgs e)
        {
            ShowWindow(this.Handle, 0);
        }
    }
}
