using System.Collections.Generic;
using SharedObjects.Models.Enums;

namespace SharedObjects.Models.Configuration
{
    public class APWConfiguration
    {
        public Country Country { get; set; }

        public List<WatchItem> ItemsToWatch { get; set; } = new List<WatchItem>();
    }
}