using System;
using System.Threading.Tasks;
using NetworkTolerance.Framework.Keys;
using NetworkTolerance.PlatformAPIs;
using Prism.Navigation;
using Prism.Services;
using PropertyChanged;
using Xamarin.Essentials;
using Xamarin.Forms;
using DependencyService = Xamarin.Forms.DependencyService;

namespace NetworkTolerance.UI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : IDisposable
    {
        private readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Xamarin.Essentials.Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private async void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _navigationService.NavigateAsync(NavKeys.NetworkUnavailablePage);
            }
            else
            {
                await _navigationService.NavigateAsync($"/{NavKeys.DevelopersPage}");
            }
        }

        public void Dispose()
        {
            Xamarin.Essentials.Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}