using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Member : IMember
    {
        public Member(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public Member(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
