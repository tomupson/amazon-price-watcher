namespace AmazonPriceWatcher.Data;

internal static class XPathConstants
{
    public const string Product = "//*[@id=\"dp\"]";

    public const string AvailabilityFeature = "//*[@id=\"availability_feature_div\"]";

    public const string PriceFeature = "//*[@id=\"unifiedPrice_feature_div\"]";
    public const string Price = "//*[@id=\"priceblock_ourprice\"]";
    public const string PriceDeal = "//*[@id=\"priceblock_dealprice\"]";
}
