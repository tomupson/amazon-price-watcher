using System;
using System.Globalization;
using apw.Exceptions;
using HtmlAgilityPack;
using SharedObjects.Models.Enums;

namespace apw.Helpers
{
    public static class PriceHelper
    {
        private const string PRICE_DIV_XPATH = "//*[@id=\"unifiedPrice_feature_div\"]";
        private const string PRICE_XPATH = "//*[@id=\"priceblock_ourprice\"]";

        public static decimal GetCurrentPrice(HtmlDocument doc, Country country)
        {
            HtmlNode priceDiv = doc.DocumentNode.SelectSingleNode(PRICE_DIV_XPATH);

            if (priceDiv == null)
            {
                throw new APWException($"Could not find the node that corresponds to the price of the requested product (xpath: {PRICE_DIV_XPATH})");
            }

            if (string.IsNullOrWhiteSpace(priceDiv.InnerText))
            {
                Console.WriteLine("The requested product cannot be price checked as it is currently unavailable");
            }

            HtmlNode priceNode = priceDiv.SelectSingleNode(PRICE_XPATH);

            if (decimal.TryParse(priceNode.InnerText, NumberStyles.Currency, LocalisationHelper.GetCultureInfo(country), out decimal price))
            {
                return price;
            }

            throw new APWException("The price node was not empty, but the price could not be parsed");
        }
    }
}