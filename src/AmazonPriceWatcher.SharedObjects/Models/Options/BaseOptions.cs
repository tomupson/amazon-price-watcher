using CommandLine;

namespace AmazonPriceWatcher.SharedObjects.Models.Options;

public abstract class BaseOptions
{
    [Option('v', "verbose", HelpText = "Tells the command to log more verbosely", Required = false, Default = false)]
    public bool Verbose { get; set; }
}
