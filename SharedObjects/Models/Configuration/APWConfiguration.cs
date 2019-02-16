using System.Collections.Generic;

namespace SharedObjects.Models.Configuration
{
    public class APWConfiguration
    {
        public List<WatchItem> ItemsToWatch { get; set; } = new List<WatchItem>();
    }
}