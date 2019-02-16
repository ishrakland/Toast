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
            CrossToastPopUp.Current.ShowToastMessage("Test");
        }

        private void Toast2Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Green", "#008000", "#000000");
        }

        private void Toast3Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Aqua", "#00FFFF");
        }

        private void Toast4Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Blue", "#0000FF", "#FFFFFF");
        }
    }
}
