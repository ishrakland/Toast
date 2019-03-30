using System;

namespace Plugin.Toast.Abstractions
{
    public interface IToastPopUp
    {
        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toastLength">Toast length: short = 2 seconds OR long = 3.5 seconds. Optional, defaults to short.</param>
        void ShowCustomToast(string message, string bgColor, string txtColor, ToastLength toastLength = ToastLength.SHORT);


        /// <summary>
        /// ShowToastMessage display a Toast MESSAGE
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Toast length: short = 2 seconds OR long = 3.5 seconds. Optional, defaults to short.</param>
        void ShowToastMessage(string message, ToastLength toastLength = ToastLength.SHORT);

        /// <summary>
        /// ShowToastError display a Toast ERROR
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Toast length: short = 2 seconds OR long = 3.5 seconds. Optional, defaults to short.</param>
        void ShowToastError(string message, ToastLength toastLength = ToastLength.SHORT);

        /// <summary>
        /// ShowToastWarning display a Toast Warning
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Toast length: short = 2 seconds OR long = 3.5 seconds. Optional, defaults to short.</param>
        void ShowToastWarning(string message, ToastLength toastLength = ToastLength.SHORT);

        /// <summary>
        /// ShowToastSuccess display a Toast Success
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="toastLength">Toast length: short = 2 seconds OR long = 3.5 seconds. Optional, defaults to short.</param>
        void ShowToastSuccess(string message, ToastLength toastLength = ToastLength.SHORT);
    }
}
