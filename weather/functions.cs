using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.functions
{
    public class functions
    {
        public static void sendMessage(string text)
        {
            ToastContentBuilder toastContentBuilder = new ToastContentBuilder();
            toastContentBuilder.AddText(text);
            toastContentBuilder.Show();
        }

        public static void sendErrMessage()
        {
            sendMessage("Произошёл какой-то капец. Скорее всего неверный токен. Открываю окно настроек...");
        }
    }
}
