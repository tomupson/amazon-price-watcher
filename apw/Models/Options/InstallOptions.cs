using CommandLine;

namespace apw.Models.Options
{
    [Verb("install")]
    internal class InstallOptions
    {
        [Option('f', "freq", HelpText = "Delay (in seconds) between price checks", Required = false, Default = 90)]
        public int Frequency { get; set; }
    }
}