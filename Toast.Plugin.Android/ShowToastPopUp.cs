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
        private static Android.Widget.Toast _instance;

        /// <summary>
        /// Show a Toast Error
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message)
        {
            ShowMessage(message, "#9f333c", "#ffffff");
        }

        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            ShowMessage(message, "#000000", "#ffffff");
        }
      
        public void ShowToastSuccess(string message)
        {
            ShowMessage(message, "#70B771", "#ffffff");
        }

        public void ShowToastWarning(string message)
        {
            ShowMessage(message, "#faaa1d", "#ffffff");         
        }

        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="backgroundHexColor"></param>
        private void ShowMessage(string message, string backgroundHexColor = null, string textHexColor = null)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            _instance?.Cancel();
            _instance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            View tView = _instance.View;
            if (!string.IsNullOrEmpty(backgroundHexColor))
                tView.Background.SetColorFilter(Color.ParseColor(backgroundHexColor), PorterDuff.Mode.SrcIn);//Gets the actual oval background of the Toast then sets the color filter

            TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
            if (!string.IsNullOrEmpty(textHexColor))
                text.SetTextColor(Color.ParseColor(textHexColor));
            _instance.Show();
        }

    }
}
