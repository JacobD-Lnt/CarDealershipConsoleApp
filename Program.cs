using System;
using System.IO;

namespace CarDealershipConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CarDealership dealership = new CarDealership();

            using (var reader = new StreamReader(@"./data/auto-mpg.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    dealership.MakeCarWithDataLine(line);
                }
            }

            dealership.SearchForCar(
                new decimal[] { 10000, 12500 }, // price range
                18, // mpg
                8, // cylinders
                307, // displacement
                130, // horsepower
                3504, // weight
                12, // acceleration
                70, // model year
                1, // origin
                "chevorlet chevelle malibu" // car name
            );

            // dealership.SearchForCar(
            //     new decimal[] { 15000, 17000 }, // price range
            //     17, // mpg
            //     8, // cylinders
            //     302, // displacement
            //     140, // horsepower
            //     3449, // weight
            //     10.5f, // acceleration
            //     70, // model year
            //     1, // origin
            //     "idk" // car name
            // );
        }
    }
}
