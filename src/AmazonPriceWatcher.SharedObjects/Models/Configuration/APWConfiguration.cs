using AmazonPriceWatcher.SharedObjects.Models.Enums;

namespace AmazonPriceWatcher.SharedObjects.Models.Configuration;

public sealed class APWConfiguration
{
    public Country Country { get; set; }

    public List<WatchItem> ItemsToWatch { get; set; } = new List<WatchItem>();
}
