using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        //Read data from the console
        //Process data
        //Print data on the console

        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            //Place bussiness logic
            try
            {
                this.ParsePeopleInput();

                this.ParseProductInput();

                string command;
                while ((command = Console.ReadLine()) != "END") 
                {
                    string[] cmdArg = command
                        .Split(' ', 
                            StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArg[0];
                    string productName = cmdArg[1];

                    Person person = this.people
                        .FirstOrDefault(x => x.Name == personName);

                    Product product = this.products
                        .FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] peopleArgs = Console.ReadLine()
                            .Split(';',
                                StringSplitOptions.RemoveEmptyEntries);

            foreach (string personStr in peopleArgs)
            {
                string[] personArgs = personStr
                    .Split('=');

                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personMoney, personName);

                this.people.Add(person);
            }
        }

        private void ParseProductInput()
        {
            string[] productsArgs = Console.ReadLine()
                            .Split(';',
                                StringSplitOptions.RemoveEmptyEntries);

            foreach (string productStr in productsArgs)
            {
                string[] productArgs = productStr
                    .Split('=');

                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }
    }
}
