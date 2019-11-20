using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkTolerance.Framework.Attributes;
using NetworkTolerance.Framework.Keys;
using NetworkTolerance.Models;
using Refit;

namespace NetworkTolerance.Connectivity.APIs
{
    [Url(AppConstants.BaseApiUrl)]
    [Headers("Accept: application/json")]
    public interface IDwcApi
    {
        //The GET param is empty because we are using a temporary API Url dirict to the json file.
        [Get("")]
        Task<IEnumerable<Developer>> GetDevelopers();
    }
}