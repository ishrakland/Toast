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
        void ShowToast(string message, string bgColor, string txtColor)
        {
            ShowToastAlert(message, SHORT_DELAY, bgColor, txtColor);
        }
        void ShowToastAlert(string message, double seconds, string bgColor, string txtColor)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            var tView = alert.View;
            if (!string.IsNullOrEmpty(bgColor)) { tView.BackgroundColor = UIColor.Clear.FromHexString(txtColor); }
            if (!string.IsNullOrEmpty(txtColor))
            {
                tView.TintColor = UIColor.Clear.FromHexString(txtColor);
            }
            
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
        public void ShowToastMessage(string message, string bgColor, string txtColor)
        {
            ShowToast(message, bgColor, txtColor);
        }

    }
}
