using AmazonPriceWatcher.SharedObjects.Models.Enums;
using AmazonPriceWatcher.SharedObjects.Models.Options;
using CommandLine;

namespace AmazonPriceWatcher.Cli.Models.Options;

[Verb("install")]
internal sealed class InstallOptions : BaseOptions
{
    [Option('f', "freq", HelpText = "Delay (in seconds) between price checks", Required = false, Default = 90)]
    public int Frequency { get; set; }

    [Option('c', "country", HelpText = "Sets the target country", Required = false, Default = Country.UnitedKingdom)]
    public Country Country { get; set; }

    [Option('r', "reinstall", HelpText = "Forces APW to reinstall itself, even if it's already install on the machine", Required = false, Default = false)]
    public bool ForceReinstallTask { get; set; }
}
