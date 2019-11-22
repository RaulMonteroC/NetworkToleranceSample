using Foundation;
using Xamarin.Forms;
using NetworkTolerance.iOS.PlatformAPIs;
using NetworkTolerance.PlatformAPIs;
using UIKit;

[assembly: Dependency(typeof(iOSSettingsNavigator))]
namespace NetworkTolerance.iOS.PlatformAPIs
{
    public class iOSSettingsNavigator : ISettingsNavigator
    {
        public void NavigateToNetworkSettings()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=WIFI"));
        }
    }
}