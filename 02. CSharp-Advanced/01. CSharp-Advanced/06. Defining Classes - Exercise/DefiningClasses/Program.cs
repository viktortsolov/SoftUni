using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var cmdArg = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg.Length == 2)
                {
                    string model = cmdArg[0];
                    int power = int.Parse(cmdArg[1]);

                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (cmdArg.Length == 3)
                {
                    string model = cmdArg[0];
                    int power = int.Parse(cmdArg[1]);

                    int displacement;
                    bool sucess = int.TryParse(cmdArg[2], out displacement);

                    if (sucess)
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = cmdArg[2];
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else
                {
                    string model = cmdArg[0];
                    int power = int.Parse(cmdArg[1]);
                    int displacement = int.Parse(cmdArg[2]);
                    string efficiency = cmdArg[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
            }

            n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var cmdArg = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg.Length == 2)
                {
                    string model = cmdArg[0];
                    Engine engine = engines.FirstOrDefault(x => x.Model == cmdArg[1]);

                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
                else if (cmdArg.Length == 3)
                {
                    string model = cmdArg[0];
                    Engine engine = engines.FirstOrDefault(x => x.Model == cmdArg[1]);

                    int weight;
                    bool sucess = int.TryParse(cmdArg[2], out weight);

                    if (sucess)
                    {
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        string efficiency = cmdArg[2];
                        Car car = new Car(model, engine, efficiency);
                        cars.Add(car);
                    }
                }
                else
                {
                    string model = cmdArg[0];
                    Engine engine = engines.FirstOrDefault(x => x.Model == cmdArg[1]);
                    int weight = int.Parse(cmdArg[2]);
                    string color = cmdArg[3];

                    Car car = new Car(model, engine, weight, color);
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"{car.Model}:");
                sb.AppendLine($"  {car.Engine.Model}:");

                if (car.Color != null && car.Weight != 0)
                {
                    if (car.Engine.Efficiency != null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency != null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }
                }
                else if (car.Color == null && car.Weight != 0)
                {
                    if (car.Engine.Efficiency != null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency != null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: {car.Weight}");
                        sb.AppendLine($"  Color: n/a");
                    }
                }
                else if (car.Color != null && car.Weight == 0)
                {
                    if (car.Engine.Efficiency != null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: {car.Color}");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency != null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: {car.Color}");
                    }
                }
                else if (car.Color == null && car.Weight == 0)
                {
                    if (car.Engine.Efficiency != null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement != 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency == null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: n/a");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: n/a");

                        Console.WriteLine(sb.ToString().TrimEnd());
                    }

                    else if (car.Engine.Efficiency != null && car.Engine.Displacement == 0)
                    {
                        sb.AppendLine($"    Power: {car.Engine.Power}");
                        sb.AppendLine($"    Displacement: n/a");
                        sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                        sb.AppendLine($"  Weight: n/a");
                        sb.AppendLine($"  Color: n/a");
                    }
                }
            }
        }
    }
}
