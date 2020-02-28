using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        ToastLength toastLength = ToastLength.Short;
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            //If the switch is toggled then use the long duration else use the short duration
            toastLength = e.Value ? ToastLength.Long : ToastLength.Short;
        }

        private void Toast1Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Message", toastLength);
        }

        private void Toast2Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastSuccess("Success", toastLength);
        }

        private void Toast3Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastWarning("Warning", toastLength);
        }

        private void Toast4Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastError("Error", toastLength);
        }

        private void Toast5Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowCustomToast("Custom Toast", "#EE82EE", "#4d4c49", toastLength);
        }
        private async void Toast6Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Toast 1", toastLength);
            await Task.Delay(1500);
            CrossToastPopUp.Current.ShowToastMessage("Toast 2", toastLength);  
        }
    }
}
