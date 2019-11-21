using Polly;

namespace NetworkTolerance.Connectivity.Policies
{
    public interface IPolicy
    {
        IAsyncPolicy GeneratePolicy();
        IAsyncPolicy<TResult> GeneratePolicy<TResult>();
    }
}