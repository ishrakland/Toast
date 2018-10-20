using Android.Graphics;
using Android.Views;
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
        public void ShowToastMessage(string message, string bgColor, string txtColor)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            if (toastInstance != null)
                toastInstance.Cancel();
            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            View tView = toastInstance.View;
            if (!string.IsNullOrEmpty(bgColor)) { tView.SetBackgroundColor(Color.ParseColor(bgColor)); }
            if (!string.IsNullOrEmpty(txtColor))
            {
                TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
                text.SetShadowLayer(0, 0, 0, Color.Transparent);
                text.SetTextColor(Color.ParseColor(txtColor));
            }
            toastInstance.Show();
        }
    }
}
