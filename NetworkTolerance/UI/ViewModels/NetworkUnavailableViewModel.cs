using System.Threading.Tasks;
using System.Windows.Input;
using NetworkTolerance.Framework.Keys;
using NetworkTolerance.PlatformAPIs;
using Prism.AppModel;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NetworkTolerance.UI.ViewModels
{
    public class NetworkUnavailableViewModel : BaseViewModel
    {
        public ICommand NavigateToPreferencesCommand { get; set; }

        public NetworkUnavailableViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            NavigateToPreferencesCommand = new Command(OnNavigateToPreferencesCommand);   
        }

        private void OnNavigateToPreferencesCommand()
        {
            DependencyService.Get<ISettingsNavigator>().NavigateToNetworkSettings();   
        }
    }
}