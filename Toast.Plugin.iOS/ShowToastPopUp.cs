using CoreGraphics;
using Foundation;
using Plugin.Toast.Abstractions;
using UIKit;

namespace Plugin.Toast
{
    /// <summary>
    /// Show Toast PopUp
    /// </summary>
    public class ShowToastPopUp : IToastPopUp
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;
        void ShowToast(string message, UIColor bgColor, UIColor txtColor)
        {
            ShowToastAlert(message, SHORT_DELAY, bgColor, txtColor);
        }
        void ShowToastAlert(string message, double seconds, UIColor bgColor, UIColor txtColor)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            var tView = alert.View;
            tView.BackgroundColor = bgColor;
            tView.TintColor = txtColor;            
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
        void DismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
              
        /// <summary>
        /// Show Message
        /// in a Toast
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message)
        {
            ShowToast(message, UIColor.Black, UIColor.White);
        }

        /// <summary>
        /// ShowToastError
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message)
        {
            ShowToast(message, UIColor.FromRGB(159, 51, 60), UIColor.White);
        }

        /// <summary>
        /// ShowToastWarning
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message)
        {
            ShowToast(message, UIColor.FromRGB(250, 170, 29), UIColor.White);
        }

        /// <summary>
        /// ShowToastSuccess
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message)
        {
            ShowToast(message, UIColor.FromRGB(112, 183, 113), UIColor.White);
        }
    }
}
