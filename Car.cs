using System;

namespace CarDealershipConsoleApp
{
    record Car
    {
        private Random _rng = new Random();

        public decimal Price;
        public int MilesPerGallon;
        public int Cylinders;
        public int EngineDisplacement;
        public int Horsepower;
        public int Weight;
        public float Acceleration;
        public int ModelYear;
        public int Origin;
        public string CarName;

        public Car(string line)
        {
            var lineValues = line.Split(',');

            Int32.TryParse(lineValues[0], out MilesPerGallon);
            Int32.TryParse(lineValues[1], out Cylinders);
            Int32.TryParse(lineValues[2], out EngineDisplacement);

            bool verifyHorsepower = Int32.TryParse(lineValues[3], out Horsepower);

            if (!verifyHorsepower)
            {
                Horsepower = -1;
            }

            Int32.TryParse(lineValues[4], out Weight);
            float.TryParse(lineValues[5], out Acceleration);
            Int32.TryParse(lineValues[6], out ModelYear);
            Int32.TryParse(lineValues[7], out Origin);

            CarName = lineValues[8];

            this.SetPrice(Math.Round((decimal)((_rng.NextDouble() * 10000) + 10000), 2));
        }

        public void SetPrice(decimal price)
        {
            this.Price = price;
        }

        public override string ToString()
        {
            return $"price: {Price}, mpg: {MilesPerGallon}, cylinders: {Cylinders}, displacement: {EngineDisplacement}, horsepower: {Horsepower}, weight: {Weight}, acceleration: {Acceleration}, model year: {ModelYear}, origin: {Origin}, car name: {CarName}";
        }
    }
}