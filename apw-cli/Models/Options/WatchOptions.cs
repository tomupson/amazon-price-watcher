using CommandLine;

namespace apw.Models.Options
{
    [Verb("watch")]
    internal class WatchOptions : BaseOptions
    {
        [Value(0, Required = true, HelpText = "The url or code of the product to watch", MetaName = nameof(ProductUrl))]
        public string ProductUrl { get; set; }
    }
}