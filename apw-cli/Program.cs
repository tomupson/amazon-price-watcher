using System;
using System.Linq;
using apw.Models.Options;
using CommandLine;
using Microsoft.Win32.TaskScheduler;

namespace apw
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<WatchOptions, InstallOptions, CheckOptions>(args)
                .MapResult((WatchOptions options) =>
                {
                    Console.WriteLine(options.ProductUrl);
                    Console.ReadKey();
                    return 1;
                }, (InstallOptions options) =>
                {
                    Console.WriteLine(options.Frequency);

                    try
                    {
                        using (TaskService ts = new TaskService())
                        {
                            if (!options.ForceReinstallTask && ts.AllTasks.Any(t => t.Folder.Name == "APW" && t.Name == "APWPriceWatcher"))
                            {
                                Console.WriteLine("APW is already installed on your machine!");
                                return 1;
                            }

                            ts.GetFolder("APW")?.DeleteTask("APWPriceWatcher", false);

                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "Executes 'apw check' to check all items on the watchlist";
                            td.RegistrationInfo.Author = "Tom Upson";

                            LogonTrigger trigger = (LogonTrigger)Trigger.CreateTrigger(TaskTriggerType.Logon);
                            trigger.Delay = TimeSpan.FromSeconds(30);
                            trigger.Repetition = new RepetitionPattern(TimeSpan.FromSeconds(90), TimeSpan.Zero, true);

                            td.Triggers.Add(trigger);

                            td.Actions.Add(new ExecAction("apw", "check"));

                            TaskFolder folder = ts.GetFolder("APW");
                            if (folder == null)
                            {
                                try
                                {
                                    folder = ts.RootFolder.CreateFolder("APW");
                                } catch
                                {
                                    // ignored
                                }
                            }

                            folder?.RegisterTaskDefinition("APWPriceWatcher", td);
                        }
                    } catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("'apw install' can only be run in administrator mode!");
                        Console.WriteLine(ex);
                    }

                    Console.ReadKey();
                    return 1;
                },  (CheckOptions options) =>
                {
                    Console.WriteLine("Running \"check\"");
                    Console.ReadKey();
                    return 1;
                }, errors =>
                {
                    Console.WriteLine("Errors occurred parsing the command.");
                    foreach (Error error in errors)
                    {
                        Console.WriteLine(error);
                    }

                    return 1;
                });
        }
    }
}