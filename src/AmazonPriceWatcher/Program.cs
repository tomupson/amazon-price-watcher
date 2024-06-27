using AmazonPriceWatcher.Data;
using AmazonPriceWatcher.Exceptions;
using AmazonPriceWatcher.Helpers;
using AmazonPriceWatcher.Models.Options;
using AmazonPriceWatcher.SharedObjects.Models.Configuration;
using AmazonPriceWatcher.SharedObjects.Models.Enums;
using CommandLine;
using HtmlAgilityPack;

namespace AmazonPriceWatcher;

internal static class Program
{
    private static readonly APWConfiguration mockConfiguration = new APWConfiguration
    {
        Country = Country.UnitedKingdom,
        ItemsToWatch = new List<WatchItem>
        {
            new AvailabilityWatchItem { ProductCode = "B06XRWYXJY" },
            new PriceWatchItem { ProductCode = "B0791RGQW3" }
        }
    };

    private static async Task ProcessItemAsync(RunOptions options, WatchItem item)
    {
        string tld = LocalisationHelper.GetLocalisedTld(mockConfiguration.Country);
        string url = $"https://amazon.{tld}/dp/{item.ProductCode}";
        string html = await WebHelper.GetHtml(url);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        HtmlNode dp = doc.DocumentNode.SelectSingleNode(XPathConstants.Product);

        switch (item)
        {
            case AvailabilityWatchItem:
                try
                {
                    bool available = AvailablityHelper.GetAvailability(dp);
                }
                catch (APWException ex)
                {
                    Console.WriteLine("Something went wrong!");

                    if (options.Verbose)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                break;
            case PriceWatchItem:
                try
                {
                    decimal nextPrice = PriceHelper.GetCurrentPrice(dp, mockConfiguration.Country);
                }
                catch (APWException ex)
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
        RunOptions? options = null;
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
