using Plugin.Toast.Abstractions;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Plugin.Toast
{
    public class ShowToastPopUp : IToastPopUp
    {
        public void ShowToastMessage(string message, string bgColor, string txtColor)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            
            if (!string.IsNullOrEmpty(bgColor)) { ((XmlElement)toastNode).SetAttribute("bgcolor", bgColor); } // To Test
            if (!string.IsNullOrEmpty(txtColor)) // TODO
            {
               // IXmlNode txtNode = toastTextElements[0].AppendChild(toastTextElements[0].etAttribute("color", bgColor);
            }
      
            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
