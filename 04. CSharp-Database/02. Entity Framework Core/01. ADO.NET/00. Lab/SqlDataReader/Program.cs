using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDataRdr
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection dbCon = new SqlConnection(
                "Server=.; " +
                "Database=SoftUni; " +
                "Integrated Security=true");

            await dbCon.OpenAsync();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", dbCon);
                using (cmd)
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Salary = (decimal)reader["Salary"]
                            });
                        }
                    }
                }
            }

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary}");
            }
        }
    }
}
