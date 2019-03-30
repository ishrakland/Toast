﻿using System.Linq;
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

        private double ConvertCommonToastLengthToPlatformSpecific(ToastLength toastLength)
        {
            if (toastLength == ToastLength.LONG)
                return LongDelay;
            return ShortDelay;
        }


        private void ShowToast(string message, string backgroundHexColor = null, string textHexColor = null, ToastLength toastLength = ToastLength.SHORT)
        {
            double delay = ConvertCommonToastLengthToPlatformSpecific(toastLength);

            _alertDelay = NSTimer.CreateScheduledTimer(delay, (obj) =>
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
        public void ShowToastMessage(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ShowToast(message, "#000000" , "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastError
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ShowToast(message, "#9f333c", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastWarning
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ShowToast(message, "#faaa1d", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastSuccess
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message, ToastLength toastLength = ToastLength.SHORT)
        {
            ShowToast(message, "#70B771", "#ffffff", toastLength);
        }

        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bgColor"></param>
        /// <param name="txtColor"></param>
        public void ShowCustomToast(string message, string bgColor, string txtColor, ToastLength toastLength = ToastLength.SHORT)
        {
            ShowToast(message, bgColor, txtColor, toastLength);
        }
    }
}
