using System;
using System.Globalization;
using apw.Data;
using apw.Exceptions;
using HtmlAgilityPack;
using SharedObjects.Models.Enums;

namespace apw.Helpers
{
    public static class PriceHelper
    {
        public static decimal GetCurrentPrice(HtmlNode dp, Country country)
        {
            HtmlNode priceDiv = dp.SelectSingleNode(XPathConstants.PRICE_FEATURE);

            if (priceDiv == null)
            {
                throw new APWException($"Could not find the node that corresponds to the price of the requested product (xpath: {XPathConstants.PRICE_FEATURE})");
            }

            if (string.IsNullOrWhiteSpace(priceDiv.InnerText))
            {
                Console.WriteLine("The requested product cannot be price checked as it is currently unavailable");
            }

            HtmlNode priceNode = priceDiv.SelectSingleNode(XPathConstants.PRICE) ?? priceDiv.SelectSingleNode(XPathConstants.PRICE_DEAL);

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
}