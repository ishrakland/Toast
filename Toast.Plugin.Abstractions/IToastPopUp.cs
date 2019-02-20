using System;

namespace Plugin.Toast.Abstractions
{
    public interface IToastPopUp
    {
        /// <summary>
        /// ShowToastMessage display a Toast MESSAGE
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="backgroundHexColor">Background color of toast</param>
        /// <param name="textHexColor"></param>
        void ShowToastMessage(string message, string backgroundHexColor = null, string textHexColor = null);
    }
}
