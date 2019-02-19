using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private static async Task ProcessItemAsync(RunOptions options, WatchItem item)
        {
            string tld = LocalisationHelper.GetLocalisedTld(mockConfiguration.Country);
            string url = $"https://amazon.{tld}/dp/{item.ProductCode}";
            string html = await WebHelper.GetHtml(url);

            HtmlDocument doc = new HtmlDocument();
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

        private static async Task<int> Main(string[] args)
        {
            RunOptions options = null;
            int exitCode = Parser.Default.ParseArguments<RunOptions>(args).MapResult(opts =>
            {
                options = opts;
                return 1;
            }, errors =>
            {
                Console.WriteLine("Error parsing!");
                return 1;
            });

            if (options != null)
            {
                await Task.WhenAll(mockConfiguration.ItemsToWatch.Select(item => ProcessItemAsync(options, item)).ToArray());
            }

            return exitCode;
        }
    }
}