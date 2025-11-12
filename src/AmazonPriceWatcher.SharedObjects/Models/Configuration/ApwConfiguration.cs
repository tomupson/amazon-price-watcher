using AmazonPriceWatcher.SharedObjects.Models.Enums;

namespace AmazonPriceWatcher.SharedObjects.Models.Configuration;

public sealed class ApwConfiguration
{
    public Country Country { get; init; }

    public List<WatchItem> ItemsToWatch { get; init; } = new List<WatchItem>();
}
