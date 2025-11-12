namespace AmazonPriceWatcher.SharedObjects.Models.Configuration;

public abstract class WatchItem
{
    public required string ProductCode { get; init; }
}
