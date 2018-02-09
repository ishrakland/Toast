using Foundation;
using Plugin.ToastPopUp.Abstractions;
using UIKit;

namespace Plugin.ToastPopUp
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
        void ShowToast(string message)
        {
            ShowToastAlert(message, SHORT_DELAY);
        }
        void ShowToastAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
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
            ShowToast(message);
        }

    }
}
