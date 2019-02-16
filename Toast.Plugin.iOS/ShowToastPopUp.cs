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

        public void ShowToastMessage(string message, string backgroundHexColor = null, string textHexColor = null)
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
    }
}
