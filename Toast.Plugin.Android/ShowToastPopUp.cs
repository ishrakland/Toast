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
        /// ShowToastError
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastError(string message)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            if (toastInstance != null)
                toastInstance.Cancel();
            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            View tView = toastInstance.View;
            tView.SetBackgroundColor(Color.ParseColor("#9f333c"));
            TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
            text.SetShadowLayer(0, 0, 0, Color.Transparent);
            text.SetTextColor(Color.White);
            toastInstance.Show();
        }

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
            View tView = toastInstance.View;
            CornerPathEffect cornerPathEffect = new CornerPathEffect(20);
            TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
            text.SetShadowLayer(0, 0, 0, Color.Transparent);
            toastInstance.Show();
        }

        /// <summary>
        /// ShowToastSuccess
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastSuccess(string message)
        {  
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            if (toastInstance != null)
                toastInstance.Cancel();
            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            View tView = toastInstance.View;
            tView.SetBackgroundColor(Color.ParseColor("#70B771"));
            TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
            text.SetShadowLayer(0, 0, 0, Color.Transparent);
            text.SetTextColor(Color.White);
            toastInstance.Show();

        }

        /// <summary>
        /// ShowToastWarning
        /// </summary>
        /// <param name="message"></param>
        public void ShowToastWarning(string message)
        {
            // To dismiss existing toast, otherwise, the screen will be populated with it if the user do so
            if (toastInstance != null)
                toastInstance.Cancel();
            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
            View tView = toastInstance.View;
            tView.SetBackgroundColor(Color.ParseColor("#faaa1d"));
            TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
            text.SetShadowLayer(0, 0, 0, Color.Transparent);
            text.SetTextColor(Color.White);
            toastInstance.Show();
        }
    }
}
