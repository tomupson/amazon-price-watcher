using System;
using System.Collections.Generic;
using System.Linq;
using apw.Helpers;
using apw.Models.Options;
using CommandLine;
using HtmlAgilityPack;
using SharedObjects.Models.Configuration;

namespace apw
{
    internal class Program
    {
        private const string AVAILABILITY_NODE_ID = "availability_feature_div";

        private static APWConfiguration mockConfiguration = new APWConfiguration
        {
            ItemsToWatch = new List<WatchItem>
            {
                new AvailabilityWatchItem { Url = "https://www.amazon.co.uk/dp/B01J66BMXC" },
                new AvailabilityWatchItem { Url = "https://www.amazon.co.uk/dp/B0134EW7G8" }
            }
        };

        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<RunOptions>(args).MapResult(options =>
            {
                foreach (WatchItem item in mockConfiguration.ItemsToWatch)
                {
                    HtmlDocument doc = new HtmlDocument();

                    // TODO: Properly make this asynchronous
                    string html = WebHelper.GetHtml(item.Url).Result;
                    doc.LoadHtml(html);

                    switch (item)
                    {
                        case AvailabilityWatchItem availabilityItem:
                            HtmlNode availabilityNode = doc.DocumentNode.Descendants().Where(n => n.NodeType == HtmlNodeType.Element && n.Name == "div")
                                .FirstOrDefault(e => e.GetAttributeValue("id", "").Equals(AVAILABILITY_NODE_ID, StringComparison.OrdinalIgnoreCase));

                            if (availabilityNode == null)
                            {
                                Console.WriteLine("Something went wrong");
                                if (options.Verbose)
                                {
                                    Console.WriteLine($"The node \"#{AVAILABILITY_NODE_ID}\" could not be found");
                                }

                                continue;
                            }

                            bool available = string.IsNullOrWhiteSpace(availabilityNode.InnerText.Replace("\n", "").Replace("\t", ""));

                            break;
                        case PriceWatchItem priceItem:

                            break;
                    }
                }

                return 1;
            }, errors => 1);
        }
    }
}