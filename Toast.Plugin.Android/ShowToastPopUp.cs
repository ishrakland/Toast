using Android.Widget;
using Plugin.Toast.Abstractions;

namespace Plugin.Toast
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