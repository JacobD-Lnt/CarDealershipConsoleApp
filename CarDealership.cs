using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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


        // if a search field is empty, assume it is -1 or blank
        public void SearchForCar(decimal[] priceRange, int mpg, int cylinders, int displacement, int horsepower, int weight, float acceleration, int modelYear, int origin, string carName)
        {
            Dictionary<Car, int> searchDictionary = new Dictionary<Car, int>();

            int maxPoints = 0;

            foreach (Car someCar in Inventory)
            {
                int points = 0;

                if (someCar.Price > priceRange[0] && someCar.Price < priceRange[1]) points += 4;

                points += (int)((20000 - (someCar.Price)) / 5000);

                if (Math.Abs(someCar.MilesPerGallon - mpg) < 2) points++;

                if (someCar.Cylinders == cylinders) points++;

                if (Math.Abs(someCar.EngineDisplacement - displacement) < 20) points++;

                if (someCar.Horsepower != -1 && Math.Abs(someCar.Horsepower - horsepower) < 10) points++;

                if (Math.Abs(someCar.Weight - weight) < 200) points++;

                if (Math.Abs(someCar.Acceleration - acceleration) < 1) points++;

                if (someCar.ModelYear == modelYear) points++;

                if (someCar.Origin == origin) points++;

                string[] nameValues = carName.Split(',');

                foreach (string name in nameValues)
                {
                    if (someCar.CarName.Contains(name)) points++;
                }

                searchDictionary.Add(someCar, points);

                if (points > maxPoints) maxPoints = points;
            }

            //List<Car> searchResults = new List<Car>();

            foreach (KeyValuePair<Car, int> result in searchDictionary.OrderBy(key => -key.Value))
            {
                if (result.Value > ((float)maxPoints / 2f) + 1)
                {
                    Console.WriteLine($"{result.Key.ToString()}");
                }
            }
        }
    }
}