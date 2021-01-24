using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Member : IMember
    {
        public Member(string name, int age, long id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public Member(string model, long id)
        {
            this.Model = model;
            this.Id = id;
        }

        public Member(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Model { get; set; }
        public long Id { get; set; }
        public string Birthdate { get; set; }
    }
}
