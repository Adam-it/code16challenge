using System;
using System.Configuration;
using System.Threading;
using Windows.UI.Notifications;

namespace DeveloperHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);               
                toastXml.GetElementsByTagName("text")[0].AppendChild(toastXml.CreateTextNode(ConfigurationManager.AppSettings[$"message{new Random().Next(1, 11)}"]));
                ToastNotificationManager.CreateToastNotifier(nameof(DeveloperHelper)).Show(new ToastNotification(toastXml));
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["sleep"]));
            }
        }
    }
}
