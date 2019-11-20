namespace NetworkTolerance.Connectivity
{
    public interface IApiService<TApi>
    {
        TApi Api { get; }
    }
}