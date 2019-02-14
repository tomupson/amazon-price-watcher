using CommandLine;

namespace apw.Models.Options
{
    [Verb("install")]
    internal class InstallOptions : BaseOptions
    {
        [Option('f', "freq", HelpText = "Delay (in seconds) between price checks", Required = false, Default = 90)]
        public int Frequency { get; set; }

        [Option('r', "reinstall", HelpText = "Forces APW to reinstall itself, even if it's already install on the machine", Required = false, Default = false)]
        public bool ForceReinstallTask { get; set; }
    }
}