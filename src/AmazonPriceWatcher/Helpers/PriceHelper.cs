using System.Globalization;
using AmazonPriceWatcher.Data;
using AmazonPriceWatcher.Exceptions;
using AmazonPriceWatcher.SharedObjects.Models.Enums;
using HtmlAgilityPack;

namespace AmazonPriceWatcher.Helpers;

internal static class PriceHelper
{
    public static decimal GetCurrentPrice(HtmlNode dp, Country country)
    {
        HtmlNode priceDiv = dp.SelectSingleNode(XPathConstants.PriceFeature)
            ?? throw new APWException($"Could not find the node that corresponds to the price of the requested product (xpath: {XPathConstants.PriceFeature})");

        if (string.IsNullOrWhiteSpace(priceDiv.InnerText))
        {
            Console.WriteLine("The requested product cannot be price checked as it is currently unavailable");
        }

        HtmlNode priceNode = priceDiv.SelectSingleNode(XPathConstants.Price) ?? priceDiv.SelectSingleNode(XPathConstants.PriceDeal);

        if (priceNode == null || string.IsNullOrWhiteSpace(priceNode.InnerText))
        {
            throw new APWException("The price node was not empty, but no price could be found");
        }

        if (decimal.TryParse(priceNode.InnerText, NumberStyles.Currency, LocalisationHelper.GetCultureInfo(country), out decimal price))
        {
            return price;
        }

        throw new APWException("The price node was not empty, but the price could not be parsed");
    }
}
