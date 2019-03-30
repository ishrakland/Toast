using Plugin.Toast.Abstractions;
using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Plugin.Toast
{
    public class ShowToastPopUp : IToastPopUp
    {
        private System.DateTimeOffset ConvertCommonToastLengthToPlatformSpecific(ToastLength toastLength)
        {
            if (toastLength == ToastLength.LONG)
                return new System.DateTimeOffset(DateTime.Now, TimeSpan.FromSeconds(3.5));
            return new System.DateTimeOffset(DateTime.Now, TimeSpan.FromSeconds(2));
        }

        public void ShowToastError(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowToastMessage(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowToastSuccess(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowToastWarning(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowToastMessage(string message, string backgroundHexColor = null, string textHexColor = null, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowCustomToast(string message, string bgColor, string txtColor, ToastLength toastLength = ToastLength.SHORT)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            // Set Text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].InnerText = message;
            // toast duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast notification based on the XML content you've specified.
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            // Send your toast notification.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
