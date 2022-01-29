using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace weather.errorforms
{
    public partial class notoken : Form
    {

        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\my_weather_widget");
        public notoken()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "ua";   
        }
        private void notoken_Load(object sender, EventArgs e)
        {
            if (key.GetValue("token")==null)
            {
                textBox1.Text = "Токена нет!! Где токен, липковски? ГДЕ ТОКЕН?";
            }
            else
            {
                textBox1.Text = key.GetValue("token").ToString();
            }

            if (key.GetValue("city") == null)
            {
                textBox2.Text = "Города нет!! Где токен, липковски? ГДЕ ТОКЕН?";
            }
            else
            {
                textBox2.Text = key.GetValue("city").ToString();
            }

            if (key.GetValue("time") == null)
            {
                textBox3.Text = "time isn't set";

            }
            else
            {
                int time = Convert.ToInt32(key.GetValue("time"));
                time /= 60000;
                textBox3.Text = time.ToString();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
 
            string token = textBox1.Text;
            string city = textBox2.Text;
            string lang = comboBox1.Text;

            int time = Convert.ToInt32(textBox3.Text);
            if (time<20)
            {
                time = 20;
            }
            time *= 60000;
            
            key.SetValue("token", token);
            key.SetValue("city", city);
            key.SetValue("lang", lang);

            if (time==0)
            {
                //label2.Text = "Ты че пес?";
            }
            else { 
                key.SetValue("time", time);
            }

            Application.Restart();
        }
    }
}
