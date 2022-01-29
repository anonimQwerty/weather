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
using weather.classes;
using weather.functions;

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

            weatherСlass wether = new weatherСlass();
            if (!wether.problems)
            {



                while (true)
                {
                    try
                    {
                        var forecast = wether.getUpd();

                        functions.functions.sendMessage($"{forecast["weather"][0]["description"]}\n Температура: {Math.Round(forecast["main"]["temp"] - 273.15, 3)} \n Ощущается как: {Math.Round(forecast["main"]["feels_like"] - 273.15, 3)} \nДавление: {forecast["main"]["pressure"]}\nСкорость ветра {forecast["wind"]["speed"]}");
                        await Task.Delay(wether.time);
                    }
                    catch
                    {

                    }

                }

            }
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

        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notoken form = new notoken();
            form.Show();
        }

        void Form1_Deactivate(object sender, EventArgs e)
        {
            ShowWindow(this.Handle, 0);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            weatherСlass wether = new weatherСlass();
            var tmpvar = wether.getUpd();
            functions.functions.sendMessage($"{tmpvar["weather"][0]["description"]}");
            
        }

        async void getDataNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(this.Handle, 0);
            notifyIcon1.Visible = true;




            try
            {
                weatherСlass wether = new weatherСlass();


                var forecast = wether.getUpd();


                functions.functions.sendMessage($"{forecast["weather"][0]["description"]}\n Температура: {Math.Round(forecast["main"]["temp"] - 273.15, 3)} \n Ощущается как: {Math.Round(forecast["main"]["feels_like"] - 273.15, 3)} \nДавление: {forecast["main"]["pressure"]}\nСкорость ветра {forecast["wind"]["speed"]}");
                await Task.Delay(wether.time);

            }
            catch
            {

            }
        }
    }
}
