using Android.Content;
using NetworkTolerance.Droid.PlatformAPIs;
using NetworkTolerance.PlatformAPIs;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSettingsNavigator))]
namespace NetworkTolerance.Droid.PlatformAPIs
{
    public class AndroidSettingsNavigator : ISettingsNavigator
    {
        public void NavigateToNetworkSettings()
        {
            Android.App.Application.Context.StartActivity(new Intent(Android.Provider.Settings.ActionWirelessSettings));
        }
    }
}