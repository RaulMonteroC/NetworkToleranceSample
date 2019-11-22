using System.Collections.ObjectModel;
using System.Linq;
using NetworkTolerance.Connectivity;
using NetworkTolerance.Connectivity.APIs;
using NetworkTolerance.Models;
using NetworkTolerance.PlatformAPIs;
using Prism.Navigation;
using Prism.Services;

namespace NetworkTolerance.UI.ViewModels
{
    public class DevelopersViewModel : BaseViewModel
    {
        public ObservableCollection<Developer> Developers { get; set; }
        public bool Loading { get; set; }
        
        private readonly IApiService<IDwcApi> _apiService;
        
        public DevelopersViewModel(INavigationService navigationService,
            IApiService<IDwcApi> apiService) : base(navigationService)
        {
            _apiService = apiService;

            LoadData();
        }

        private async void LoadData()
        {
            Loading = true;
            
            var data = await _apiService.Call(t => t.GetDevelopers(), CallPriority.User);

            if (data != null)
            {
                Developers = new ObservableCollection<Developer>(data.OrderBy(m => m.Name));
            }

            Loading = false;
        }
    }
}