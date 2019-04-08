using System;

namespace Plugin.Toast.Abstractions
{
    public interface IToastPopUp
    {

        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        void ShowCustomToast(string message, string bgColor, string txtColor, ToastLength toastLength = ToastLength.Short);


        /// <summary>
        /// ShowToastMessage display a Toast MESSAGE
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastMessage(string message, ToastLength toastLength = ToastLength.Short);

        /// <summary>
        /// ShowToastError display a Toast ERROR
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Length of the toast time on screen</param>
        void ShowToastError(string message, ToastLength toastLength = ToastLength.Short);

        /// <summary>
        /// ShowToastWarning display a Toast Warning
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Length of the toast time on screen</param>
        void ShowToastWarning(string message, ToastLength toastLength = ToastLength.Short);

        /// <summary>
        /// ShowToastSuccess display a Toast Success
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Length of the toast time on screen</param>
        void ShowToastSuccess(string message, ToastLength toastLength = ToastLength.Short);
    }

    public enum ToastLength
    {
        Short = 0,
        Long = 1
    };
}
