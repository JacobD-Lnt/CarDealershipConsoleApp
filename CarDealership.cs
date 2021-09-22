using System;
using System.Collections.Generic;
using System.Globalization;

namespace CarDealershipConsoleApp
{
    class CarDealership
    {
        public List<Car> Inventory = new List<Car>();

        private TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

        public void MakeCarWithDataLine(string line)
        {
            var lineValues = line.Split(',');

            if (Int32.TryParse(lineValues[0], out var output))
            {
                Car newCar = new Car(line);

                Inventory.Add(newCar);
            }
        }

        public void PrintInventory()
        {
            foreach (Car someCar in Inventory)
            {
                Console.WriteLine(someCar.ToString());
            }
        }

        public void BuyCar(Car someCar)
        {
            Console.WriteLine($"You paid ${someCar.Price} for a {_textInfo.ToTitleCase(someCar.CarName)}");

            Inventory.Remove(someCar);
        }
    }
}