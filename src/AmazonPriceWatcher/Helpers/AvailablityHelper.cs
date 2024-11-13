using AmazonPriceWatcher.Data;
using AmazonPriceWatcher.Exceptions;
using HtmlAgilityPack;

namespace AmazonPriceWatcher.Helpers;

internal static class AvailablityHelper
{
    public static bool GetAvailability(HtmlNode dp)
    {
        HtmlNode availabilityNode = dp.SelectSingleNode(XPathConstants.AvailabilityFeature)
            ?? throw new ApwException($"Could not find the node that corresponds to the availablity of the requested product (xpath: {XPathConstants.AvailabilityFeature})");

        return string.IsNullOrWhiteSpace(availabilityNode.InnerText);
    }
}
