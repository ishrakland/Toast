using System;

namespace Plugin.Toast.Abstractions
{
    public interface IToastPopUp
    {
        /// <summary>
        /// ShowToast display a Toast popup
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastMessage(string message);
        void ShowToastError(string message);
        void ShowToastWarning(string message);
        void ShowToastSuccess(string message);
    }
}
