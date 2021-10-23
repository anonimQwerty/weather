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

        public void button1_Click(object sender, EventArgs e)
        {
            

            
            string token = textBox1.Text;
            string city = textBox2.Text;
            string lang = comboBox1.Text;
            int time = Convert.ToInt32(textBox3.Text);
            if (time<10)
            {
                time = 10;
            }
            

            time *= 60000;
            label1.Text = lang;
            
            key.SetValue("token", token);
            key.SetValue("city", city);
            key.SetValue("lang", lang);

            if (time==0)
            {
                label2.Text = "Ты че пес?";
            }
            else { 
                key.SetValue("time", time);
            }
            

        }
    }
}
