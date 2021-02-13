using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count();
        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                data.Remove(car);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public Car GetLatestCar()
        {
            Car car = data.OrderByDescending(x => x.Year).First();
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"The cars are parked in {Type}:");
            foreach (Car car in data)
            {
                stringBuilder.AppendLine(car.ToString());
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
