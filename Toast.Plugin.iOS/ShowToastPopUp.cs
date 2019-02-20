using System.Linq;
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
        const double LongDelay = 3.5;
        const double ShortDelay = 2.0;

        NSTimer _alertDelay;
        UIAlertController _alert;

        void DismissMessage()
        {
            _alert?.DismissViewController(true, null);
            _alertDelay?.Dispose();
        }

        private void ShowToast(string message, string backgroundHexColor = null, string textHexColor = null)
        {
            _alertDelay = NSTimer.CreateScheduledTimer(ShortDelay, (obj) =>
            {
                DismissMessage();
            });

            _alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            var tView = _alert.View;
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
            _alert.SetValueForKey(attributedString, new NSString("attributedMessage"));
            IosHelper.GetVisibleViewController().PresentViewController(_alert, true, null);
        }

        /// <summary>
        /// Show Message
        /// in a Toast
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message)
        {
            ShowToast(message, "#000000" , "#ffffff");
        }

        /// <summary>
        /// ShowToastError
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message)
        {
            ShowToast(message, "#9f333c", "#ffffff");
        }

        /// <summary>
        /// ShowToastWarning
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message)
        {
            ShowToast(message, "#faaa1d", "#ffffff");
        }

        /// <summary>
        /// ShowToastSuccess
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message)
        {
            ShowToast(message, "#70B771", "#ffffff");
        }
    }
}
