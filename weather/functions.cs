using Microsoft.Toolkit.Uwp.Notifications;

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
