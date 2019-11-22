using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NetworkTolerance.UI.Pages
{
    public partial class DevelopersPage : ContentPage
    {
        public DevelopersPage()
        {
            InitializeComponent();
        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // This is to avoid the orange on selected background color on android
            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;
        }

    }
}
