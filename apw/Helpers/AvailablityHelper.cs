using apw.Exceptions;
using HtmlAgilityPack;

namespace apw.Helpers
{
    public static class AvailablityHelper
    {
        private const string AVAILABILITY_DIV_XPATH = "//*[@id=\"availability_feature_div\"]";

        public static bool GetAvailability(HtmlDocument doc)
        {
            HtmlNode availabilityNode = doc.DocumentNode.SelectSingleNode(AVAILABILITY_DIV_XPATH);

            if (availabilityNode == null)
            {
                throw new APWException($"Could not find the node that corresponds to the availablity of the requested product (xpath: {AVAILABILITY_DIV_XPATH})");
            }

            return string.IsNullOrWhiteSpace(availabilityNode.InnerText);
        }
    }
}