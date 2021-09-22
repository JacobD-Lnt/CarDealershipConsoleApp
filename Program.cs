using System;
using System.IO;

namespace CarDealershipConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var autoInfo = FileStyleUriParser.ReadAllText("./data/auto-mpg.csv");

            using (var reader = new StreamReader(@"./data/auto-mpg.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineValues = line.Split(',');


                }
            }
        }
    }
}
