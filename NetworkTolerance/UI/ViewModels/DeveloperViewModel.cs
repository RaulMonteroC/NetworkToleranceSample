using System.Collections.ObjectModel;
using System.Linq;
using NetworkTolerance.Connectivity;
using NetworkTolerance.Connectivity.APIs;
using NetworkTolerance.Models;

namespace NetworkTolerance.UI.ViewModels
{
    public class DevelopersViewModel : BaseViewModel
    {
        private readonly IApiService<IDwcApi> _apiService;

        public ObservableCollection<Developer> Developers { get; set; }

        public DevelopersViewModel(IApiService<IDwcApi> apiService)
        {
            _apiService = apiService;

            LoadData();
        }

        private async void LoadData()
        {
            var data = await _apiService.Api.GetDevelopers();
            
            Developers = new ObservableCollection<Developer>(data.OrderBy(m=>m.Name));
        }
    }
}