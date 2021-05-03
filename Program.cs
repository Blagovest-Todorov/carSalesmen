using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] engineArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = null;

                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                if (engineArgs.Length == 4)
                {
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineArgs.Length == 3)
                {
                    int displacement;
                    //string efficiency;

                    bool isDisplacement = int.TryParse(engineArgs[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArgs[2]);
                    }


                }
                else if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                   engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = null;

                string model = carArgs[0];
                Engine engine = engines.First(e => e.Model == carArgs[1]);

                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 3)
                {
                    double weight;
                    bool isWeight = double.TryParse(carArgs[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArgs[2]);
                    }
                }
                else if (carArgs.Length == 4)
                {
                    car = new Car(model, engine, double.Parse(carArgs[2]), carArgs[3]);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car}");
            }

        }
    }
}
