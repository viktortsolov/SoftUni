using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> family;

        public Family()
        {
            family = new List<Person>();
        }

        public Family Where { get; internal set; }

        public void AddMember(Person member)
        {
            family.Add(member);
        }

        public Person GetOldestMember()
        {
            return family.OrderByDescending(x => x.Age).First();
        }
    }
}
