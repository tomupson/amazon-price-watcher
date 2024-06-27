namespace apw.Data
{
    public class XPathConstants
    {
        public const string PRODUCT = "//*[@id=\"dp\"]";

        #region Availability
        public const string AVAILABILITY_FEATURE = "//*[@id=\"availability_feature_div\"]";
        #endregion

        #region Price
        public const string PRICE_FEATURE = "//*[@id=\"unifiedPrice_feature_div\"]";
        public const string PRICE = "//*[@id=\"priceblock_ourprice\"]";
        public const string PRICE_DEAL = "//*[@id=\"priceblock_dealprice\"]";
        #endregion
    }
}