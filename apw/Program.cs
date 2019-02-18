using System;
using System.Collections.Generic;
using apw.Exceptions;
using apw.Helpers;
using apw.Models.Options;
using CommandLine;
using HtmlAgilityPack;
using SharedObjects.Models.Configuration;
using SharedObjects.Models.Enums;

namespace apw
{
    internal class Program
    {
        private static APWConfiguration mockConfiguration = new APWConfiguration
        {
            Country = Country.UnitedKingdom,
            ItemsToWatch = new List<WatchItem>
            {
                new AvailabilityWatchItem { ProductCode = "B06XRWYXJY" },
                new PriceWatchItem { ProductCode = "B0134EW7G8" }
            }
        };

        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<RunOptions>(args).MapResult(options =>
            {
                foreach (WatchItem item in mockConfiguration.ItemsToWatch)
                {
                    HtmlDocument doc = new HtmlDocument();
                    string tld = LocalisationHelper.GetLocalisedTld(mockConfiguration.Country);
                    string url = $"https://amazon.{tld}/dp/{item.ProductCode}";

                    // TODO: Properly make this asynchronous
                    string html = WebHelper.GetHtml(url).Result;
                    doc.LoadHtml(html);

                    switch (item)
                    {
                        case AvailabilityWatchItem availabilityItem:
                            try
                            {
                                bool available = AvailablityHelper.GetAvailability(doc);
                            } catch (APWException ex)
                            {
                                Console.WriteLine("Something went wrong!");

                                if (options.Verbose)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            break;
                        case PriceWatchItem priceItem:
                            try
                            {
                                decimal nextPrice = PriceHelper.GetCurrentPrice(doc, mockConfiguration.Country);
                            } catch (APWException ex)
                            {
                                Console.WriteLine("Something went wrong!");

                                if (options.Verbose)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                    }
                }

                return 1;
            }, errors => 1);
        }
    }
}