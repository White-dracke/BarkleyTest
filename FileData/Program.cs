using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var argumentManipulator = new ArgumentManipulator(args);

            var result = argumentManipulator.Execute();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
