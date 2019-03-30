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
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bgColor"></param>
        /// <param name="txtColor"></param>
        public void ShowCustomToast(string message, string bgColor, string txtColor, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            ShowMessage(message, bgColor, txtColor, toastLength);
        }

        /// <summary>
        /// Show a Toast Error
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            ShowMessage(message, "#9f333c", "#ffffff", toastLength);
        }

        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastMessage(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            ShowMessage(message, "#000000", "#ffffff", toastLength);
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            ShowMessage(message, "#70B771", "#ffffff", toastLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            ShowMessage(message, "#faaa1d", "#ffffff", toastLength);         
        }


        /// <summary>
        /// Converts common ToastLength type to Android one
        /// </summary>
        /// <param name="length">Toast length</param>
        /// <returns>Android toast length</returns>
        private Android.Widget.ToastLength CommonToastLengthToPlatformSpecific(Abstractions.ToastLength length)
        {
            if (length == Abstractions.ToastLength.LONG)
                return Android.Widget.ToastLength.Long;
            return Android.Widget.ToastLength.Short;
        }

        /// <summary>
        /// ShowToastMessage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="backgroundHexColor"></param>
        private void ShowMessage(string message, string backgroundHexColor = null, string textHexColor = null, Abstractions.ToastLength toastLength = Abstractions.ToastLength.SHORT)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            _instance?.Cancel();            
            _instance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, CommonToastLengthToPlatformSpecific(toastLength));
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
