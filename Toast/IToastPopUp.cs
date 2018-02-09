namespace Plugin.ToastPopUp.Abstractions
{
    public interface IToastPopUp
    {
        /// <summary>
        /// ShowToast display a Toast popup
        /// </summary>
        /// <param name="message">Message to display</param>
        void ShowToastMessage(string message);
    }
}
