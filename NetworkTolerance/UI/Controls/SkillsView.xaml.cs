using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NetworkTolerance.UI.Controls
{
    public partial class SkillsView : ContentView
    {
        public IEnumerable<string> SkillsSource
        {
            get { return (IEnumerable<string>)GetValue(SkillsSourceProperty); }
            set { SetValue(SkillsSourceProperty, value); }
        }

        public static readonly BindableProperty SkillsSourceProperty =
            BindableProperty.Create("SkillsSource", typeof(IEnumerable<string>), typeof(CustomTitleView), null, propertyChanged: OnSkillsSourceChanged);


        public SkillsView()
        {
            InitializeComponent();
        }

        private static void OnSkillsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SkillsView)bindable;

            if (newValue != null)
                control.skillList.ItemsSource = (IEnumerable<string>)newValue;
        }
    }
}
