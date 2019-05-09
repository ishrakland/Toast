using Plugin.Toast.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Plugin.Toast
{
    public class ShowToastPopUp : IToastPopUp
    {
        Popup popup = new Popup();
        Grid grid = new Grid();

        public ShowToastPopUp()
        {
        }

        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bgColor"></param>
        /// <param name="txtColor"></param>
        public void ShowCustomToast(string message, string bgColor, string txtColor, Abstractions.ToastLength toastLength = Abstractions.ToastLength.Short)
        {
            ShowMessage(message, bgColor, txtColor, toastLength);
        }

        /// <summary>
        /// Show a Toast Error
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.Short)
        {
            ShowMessage(message, "#9f333c", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.Short)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            ShowMessage(message, "#000000", "#ffffff", toastLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.Short)
        {
            ShowMessage(message, "#70B771", "#ffffff", toastLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.Short)
        {
            ShowMessage(message, "#faaa1d", "#ffffff", toastLength);
        }
        public void ShowMessage(string message, string bgColor, string txtColor, ToastLength toastLength = ToastLength.Short)
        {
             grid = new Grid();
            if (!string.IsNullOrEmpty(bgColor))
                grid.Background = ColorToBrush(bgColor);
            TextBlock popupText = new TextBlock();
            popupText.Text = message;
            popupText.Margin = new Thickness(8);
            if (!string.IsNullOrEmpty(txtColor))
                popupText.Foreground = ColorToBrush(txtColor);
            grid.Children.Add(popupText);
            grid.CornerRadius = new CornerRadius(20);
            popup.Child = grid;
            popup.HorizontalOffset = (Window.Current.Bounds.Width) / 2;
            popup.VerticalOffset = (Window.Current.Bounds.Height - grid.ActualHeight) - 50;
            popup.IsOpen = true;

            DispatcherTimer timer = new DispatcherTimer();
            if (toastLength.Equals(ToastLength.Short))
            {
                timer.Interval = TimeSpan.FromSeconds(5);
            }
            else
            {
                timer.Interval = TimeSpan.FromSeconds(15);
            }

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {           
                ((DispatcherTimer)sender).Stop();
                if (popup.IsOpen)
                    popup.IsOpen = false;         
        }

        public static Brush ColorToBrush(string color) // color = "#E7E44D"
        {
            color = color.Replace("#", "");
            if (color.Length == 6)
            {
                return new SolidColorBrush(ColorHelper.FromArgb(255,
                    byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            else
            {
                return null;
            }
        }
   
    }
}
