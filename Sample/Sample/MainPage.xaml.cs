using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Toast;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Toast1Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Message");
        }

        private void Toast2Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastSuccess("Success");
        }

        private void Toast3Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastWarning("Warning");
        }

        private void Toast4Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastError("Error");
        }

        private void Toast5Clicked(object sender, EventArgs e)
        {

        }
    }
}
