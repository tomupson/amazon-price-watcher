using AmazonPriceWatcher.SharedObjects.Models.Options;
using CommandLine;

namespace AmazonPriceWatcher.Cli.Models.Options;

[Verb("watch")]
internal sealed class WatchOptions : BaseOptions
{
    [Value(0, Required = true, HelpText = "The url or code of the product to watch", MetaName = nameof(ProductUrl))]
    public required string ProductUrl { get; set; }
}
