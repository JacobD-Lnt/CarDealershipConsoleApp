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

            CarDealership dealership = new CarDealership();

            using (var reader = new StreamReader(@"./data/auto-mpg.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    dealership.MakeCarWithDataLine(line);
                }
            }

            dealership.PrintInventory();

            dealership.BuyCar(dealership.Inventory[0]);
        }
    }
}
