using Microsoft.Data.SqlClient;
using System;

namespace SqlConn
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=.; " +
                "Database=SoftUni; " +
                "Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", dbCon);
                using (cmd)
                {
                    var result = (int)cmd.ExecuteScalar();

                    Console.WriteLine($"Employees count: {result}");
                }
            }
        }
    }
}
