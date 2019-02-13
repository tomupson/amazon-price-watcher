using CommandLine;

namespace apw.Models.Options
{
    [Verb("watch")]
    internal class WatchOptions
    {
        [Option('u', "url", Required = true, HelpText = "Set url of product to watch")]
        public string Url { get; set; }
    }
}