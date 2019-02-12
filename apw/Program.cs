using System;

namespace apw
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}