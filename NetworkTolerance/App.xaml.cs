using System;
using NetworkTolerance.Connectivity;
using NetworkTolerance.Connectivity.APIs;
using NetworkTolerance.Framework.Keys;
using NetworkTolerance.UI.Pages;
using NetworkTolerance.UI.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkTolerance
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }
        
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(NavKeys.DevelopersPage);
        }        

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(IApiService<IDwcApi>), typeof(ApiService<IDwcApi>));

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<NetworkUnavailablePage, NetworkUnavailableViewModel>();
            containerRegistry.RegisterForNavigation<DevelopersPage, DevelopersViewModel>();
        }
    }
}
