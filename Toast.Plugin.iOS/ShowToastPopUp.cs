using System;
using System.Linq;
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
        const double LongDelay = 3.5;
        const double ShortDelay = 2.0;

        NSTimer _lastAlertDelay;
        UIAlertController _lastAlert;

        void DismissMessage(UIAlertController alert, NSTimer alertDelay, Action complete)
        {
            alert?.DismissViewController(true, complete);
            alert?.Dispose();
            alertDelay?.Dispose();
            _lastAlertDelay = null;
            _lastAlert = null;
        }

        private void ShowToast(string message, string backgroundHexColor = null, string textHexColor = null, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            if (_lastAlertDelay != null && _lastAlert != null)
            {
                DismissMessage(_lastAlert, _lastAlertDelay, () => { CreateToast(message, backgroundHexColor, textHexColor, toastLength); });
            }
            else
            {
                CreateToast(message, backgroundHexColor, textHexColor, toastLength);
            }
        }

        /// <summary>
        /// Create Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="backgroundHexColor"></param>
        /// <param name="textHexColor"></param>
        /// <param name="toastLength"></param>
        private void CreateToast(string message, string backgroundHexColor = null, string textHexColor = null, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        { 
            var delay = toastLength == ToastLength.Short ? ShortDelay : LongDelay;

            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(delay, (obj) =>
            {
                DismissMessage(alert, obj, null);
            });

            _lastAlert = alert;
            _lastAlertDelay = alertDelay;

            var tView = alert.View;
            if (!string.IsNullOrEmpty(backgroundHexColor))
            {
                var firstSubView = tView.Subviews?.FirstOrDefault();
                var alertContentView = firstSubView?.Subviews?.FirstOrDefault();
                if (alertContentView != null)
                    foreach (UIView uiView in alertContentView.Subviews)
                    {
                        uiView.BackgroundColor = UIColor.Clear.FromHexString(backgroundHexColor);
                    }
            }
            var attributedString = new NSAttributedString(message, foregroundColor: UIColor.Clear.FromHexString(textHexColor ?? "#000000"));
            alert.SetValueForKey(attributedString, new NSString("attributedMessage"));
            IosHelper.GetVisibleViewController().PresentViewController(alert, true, null);
        }

        /// <summary>
        /// Show Message
        /// in a Toast
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            ShowToast(message, "#000000" , "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastError
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            ShowToast(message, "#9f333c", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastWarning
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            ShowToast(message, "#faaa1d", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastSuccess
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            ShowToast(message, "#70B771", "#ffffff", toastLength);
        }

        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bgColor"></param>
        /// <param name="txtColor"></param>
        public void ShowCustomToast(string message, string bgColor, string txtColor, Plugin.Toast.Abstractions.ToastLength toastLength = ToastLength.Short)
        {
            ShowToast(message, bgColor, txtColor, toastLength);
        }
    }
}
