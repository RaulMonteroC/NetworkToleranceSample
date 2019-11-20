using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NetworkTolerance.UI.Controls
{
    public partial class CustomTitleView : ContentView
    {
        public string NavigationTitle
        {
            get { return (string)GetValue(NavigationTitleProperty); }
            set { SetValue(NavigationTitleProperty, value); }
        }

        public static readonly BindableProperty NavigationTitleProperty =
            BindableProperty.Create("NavigationTitle", typeof(string), typeof(CustomTitleView), string.Empty, propertyChanged: OnNavigationTitleChanged);


        public CustomTitleView()
        {
            InitializeComponent();
        }

        private static void OnNavigationTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomTitleView)bindable;

            if (newValue != null)
                control.navTitle.Text = (string)newValue;
        }
    }
}
