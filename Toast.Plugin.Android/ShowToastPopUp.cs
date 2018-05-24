using Android.Widget;
using Plugin.Toast.Abstractions;

namespace Plugin.Toast
{
    /// <summary>
/// Show Toast Popup
/// </summary>
    public class ShowToastPopUp : IToastPopUp
    {
        private static Android.Widget.Toast toastInstance;
        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            if (toastInstance != null)
                toastInstance.Cancel();
            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            toastInstance.Show();
        }
    }
}
