using System;
using apw.Models.Options;
using CommandLine;

namespace apw
{
    internal class Program
    {
        private static void Main(string[] args) => Parser.Default.ParseArguments<WatchOptions, InstallOptions>(args)
            .MapResult((WatchOptions o) =>
            {
                Console.WriteLine(o.Url);
                Console.ReadKey();
                return 1;
            }, (InstallOptions o) =>
            {
                Console.WriteLine(o.Frequency);
                Console.ReadKey();
                return 1;
            }, errors => 1);
    }
}