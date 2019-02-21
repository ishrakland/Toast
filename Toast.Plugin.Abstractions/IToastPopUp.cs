using System;

namespace Plugin.Toast.Abstractions
{
    public interface IToastPopUp
    {

        /// <summary>
        /// Show Custom Toast
        /// </summary>
        /// <param name="message"></param>
        void ShowCustomToast(string message, string bgColor, string txtColor);


        /// <summary>
        /// ShowToastMessage display a Toast MESSAGE
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastMessage(string message);

        /// <summary>
        /// ShowToastError display a Toast ERROR
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastError(string message);

        /// <summary>
        /// ShowToastWarning display a Toast Warning
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastWarning(string message);

        /// <summary>
        /// ShowToastSuccess display a Toast Success
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastSuccess(string message);
    }
}
