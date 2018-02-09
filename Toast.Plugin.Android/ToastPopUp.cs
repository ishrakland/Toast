using Android.Widget;
using Plugin.ToastPopUp.Abstractions;

namespace Plugin.ToastPopUp
{
    /// <summary>
/// Show Toast Popup
/// </summary>
    public class ShowToastPopUp : IToastPopUp
    {
        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message)
        {
            Android.Widget.Toast Task = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            Task.Show();
        }
    }
}