using apw.Data;
using apw.Exceptions;
using HtmlAgilityPack;

namespace apw.Helpers
{
    public static class AvailablityHelper
    {
        public static bool GetAvailability(HtmlNode dp)
        {
            HtmlNode availabilityNode = dp.SelectSingleNode(XPathConstants.AVAILABILITY_FEATURE);

            if (availabilityNode == null)
            {
                throw new APWException($"Could not find the node that corresponds to the availablity of the requested product (xpath: {XPathConstants.AVAILABILITY_FEATURE})");
            }

            return string.IsNullOrWhiteSpace(availabilityNode.InnerText);
        }
    }
}