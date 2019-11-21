using System;
using System.Threading.Tasks;

namespace NetworkTolerance.Connectivity
{
    public interface IApiService<TApi>
    {
        Task Call(Func<TApi, Task> apiCall);
        Task<TResult> Call<TResult>(Func<TApi, Task<TResult>> apiCall);
    }
}