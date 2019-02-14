using CommandLine;

namespace apw.Models.Options
{
    internal class BaseOptions
    {
        [Option('v', "verbose", HelpText = "Tells the command to log more than default", Required = false, Default = false)]
        public bool Verbose { get;set; }
    }
}