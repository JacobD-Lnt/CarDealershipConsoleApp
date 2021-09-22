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

            // dealership.SearchForCar(
            //     new decimal[] { 10000, 12500 }, // price range
            //     18, // mpg
            //     8, // cylinders
            //     307, // displacement
            //     130, // horsepower
            //     3504, // weight
            //     12, // acceleration
            //     70, // model year
            //     1, // origin
            //     "chevorlet chevelle malibu" // car name
            // );

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
            //     var userCommand;
            //     console.WriteLine("Please enter a command");
            //     userCommand = Console.ReadLine().Split();
            //        while(userCommand){

            //     if (userCommand == "Search" || "search")
            //     {
            //     }

            //        }
            
            while(true)
            {
                Console.WriteLine("Please enter a command");
                var userCommand = Console.ReadLine();
                if (userCommand == "quit")
                {
                    break;
                }
                var splitString = userCommand.Split(" ");
                if (splitString[0] == "search")
                {
                    // Console.WriteLine($"You searched for {splitString[1]},{splitString[2]},{splitString[3]},{splitString[4]},{splitString[5]},{splitString[6]},{splitString[7]},{splitString[8]},{splitString[9]},{splitString[10]}");
                    var priceRange = new decimal[] { 1, 2 }; // price range
                    var mpg = -1; // mpg
                    var cylinders = -1; // cylinders
                    var displacement = -1; // displacement
                    var horsepower = -1; // horsepower
                    var weight = -1; // weight
                    var acceleration = -1f; // acceleration
                    var model = -1; // model year
                    var origin = -1; // origin
                    var name = ""; // car name
                    Console.WriteLine(splitString.Length);
                    if (splitString.Length >= 3)
                    {
                        priceRange = new decimal[] { Convert.ToDecimal(splitString[1]), Convert.ToDecimal(splitString[2]) };
                        if (splitString.Length >= 4)
                        {
                            mpg = Int32.Parse(splitString[3]);
                            if (splitString.Length >= 5)
                            {
                                cylinders = Int32.Parse(splitString[4]);
                                if (splitString.Length >= 6)
                                {
                                    displacement = Int32.Parse(splitString[5]);
                                    if (splitString.Length >= 7)
                                    {
                                        horsepower = Int32.Parse(splitString[6]);
                                        if (splitString.Length >= 8)
                                        {
                                            weight = Int32.Parse(splitString[7]);
                                            if (splitString.Length >= 9)
                                            {
                                                acceleration = float.Parse(splitString[8]);
                                                if (splitString.Length >= 10)
                                                {
                                                    model = Int32.Parse(splitString[9]);
                                                    if (splitString.Length >= 11)
                                                    {
                                                        origin = Int32.Parse(splitString[10]);
                                                        if (splitString.Length >= 12)
                                                        {
                                                            name = splitString[11];
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }


                    }

                    dealership.SearchForCar(priceRange, mpg, cylinders, displacement, horsepower, weight, acceleration, model, origin, name);
                }
                userCommand = "";
            }

        }
    }
}
