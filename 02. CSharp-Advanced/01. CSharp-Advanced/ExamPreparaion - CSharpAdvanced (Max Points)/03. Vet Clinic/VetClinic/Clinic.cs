using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(x => x.Name == name);

            return this.data.Remove(pet);
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return pet;
        }
        public Pet GetOldestPet()
        {
            Pet pet = this.data.OrderByDescending(x => x.Age).First();

            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in data)
            {
                stringBuilder.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
