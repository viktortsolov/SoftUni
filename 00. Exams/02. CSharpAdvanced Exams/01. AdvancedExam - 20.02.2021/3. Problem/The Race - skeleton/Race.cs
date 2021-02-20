using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
        { 
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Racer racer)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer racer = this.data.FirstOrDefault(x => x.Name == name);

            return this.data.Remove(racer);
        }
        public Racer GetOldestRacer()
        {
            Racer racer = this.data.OrderByDescending(x => x.Age).First();

            return racer;
        }
        //NOT SO SURE
        public Racer GetRacer(string name)
        {
            Racer racer = this.data.FirstOrDefault(x => x.Name == name);

            return racer;
        }
        public Racer GetFastestRacer()
        {
            Racer racer = this.data.OrderByDescending(x => x.Car.Speed).First();

            return racer;
        }
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in data)
            {
                stringBuilder.AppendLine(racer.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
