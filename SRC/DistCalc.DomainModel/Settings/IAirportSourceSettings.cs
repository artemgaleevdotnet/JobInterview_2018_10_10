namespace DistCalc.DomainModel.Settings
{
    public interface IAirportSourceSettings
    {
        string UrlTemplate { get; }
        int RetryCount { get; }
        int EventsBeforeBreaking { get; }
        int DurationOfBreakMsec { get; }
    }
}
