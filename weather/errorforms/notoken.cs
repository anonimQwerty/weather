using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                textBox1.Text = key.GetValue("token").ToString();
            }
            catch
            {
                textBox1.Text = "Токена нет!! Где токен, липковски? ГДЕ ТОКЕН";
            }

            try
            {
                textBox2.Text = key.GetValue("city").ToString();
            }
            catch
            {
                textBox2.Text = "Города нет!! Где город, липковски? ГДЕ ТОКЕН";
            }

            try
            {
                int time = Convert.ToInt32(key.GetValue("time"));
                time /=60000;
                textBox3.Text = time.ToString();

            }
            catch
            {
                textBox3.Text = "Времени нет!! Где время, липковски? ГДЕ ТОКЕН";
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
            //label1.Text = lang;
            
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
            

        }

        
    }
}
