namespace Demo
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.SavedMoney = money;
        }

        public string Name { get; set; }
        public decimal SavedMoney { get; set; }

        public string WhatsMyName()
        {
            return $"My name is {Name}";
        }
    }
}
