using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesFullInformation(context));
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(x => x.EmployeeId)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var stringBuilder = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Deapartment = e.Department.Name,
                    Salary = e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Deapartment} - ${employee.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            Employee employee = context
                .Employees
                .First(x => x.LastName == "Nakov");
            employee.Address = address;

            context.SaveChanges();

            var employeesAddresses = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => x.Address.AddressText)
                .Take(10)
                .ToArray();

            return String.Join(Environment.NewLine, employeesAddresses);
        }

        //Problem 07
        //public static string GetEmployeesInPeriod(SoftUniContext context)

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            IQueryable<Employee> employeesToIncrease = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                            x.Department.Name == "Tool Design" ||
                            x.Department.Name == "Marketing" ||
                            x.Department.Name == "Information Services ");

            foreach (var employee in employeesToIncrease)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToIncrease
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return stringBuilder.ToString();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            Address[] seattleAddresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            Employee[] employeesSeattle = context
                .Employees
                .ToArray()
                .Where(e => seattleAddresses.Any(a=>a.AddressId == e.AddressId))
                .ToArray();

            foreach (var employee in employeesSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(seattleAddresses);

            Town town = context
                .Towns
                .First(t => t.Name == "Seattle");

            context.SaveChanges();

            return $"{seattleAddresses.Length} addresses in Seattle were deleted";
        }
    }
}
