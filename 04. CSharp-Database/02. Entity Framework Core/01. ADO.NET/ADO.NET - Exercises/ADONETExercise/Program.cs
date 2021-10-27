using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ADONETExercise
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection
                (Configuration.CONNECTION_STRING);

            sqlConnection.Open();

            Console.WriteLine("Enter minion info: ");
            var minionInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            Console.WriteLine("Enter villain info: ");
            string villainName = Console.ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            await using (sqlConnection)
            {
                await AddMinionAsync
                    (sqlConnection, minionName, minionAge, townName, villainName);
            }
        }

        //Problem 02
        static private async Task PrintVillianWithMoreThan3MinionsAsync
            (SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand
                (Queries.VILLAINS_WITH_MORE_THAN_3_MINIONS, sqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    string villainName = sqlDataReader.GetString(0);
                    int minionsCount = sqlDataReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }

        //Problem 03
        private static async Task PrintVillainMinionsInfoByIdAsync
            (SqlConnection sqlConnection, int villainId)
        {
            SqlCommand getVillainNameCommand = new SqlCommand
                (Queries.VILLAIN_NAME_BY_ID, sqlConnection);

            //Prevents SQL Infection
            getVillainNameCommand.Parameters.AddWithValue("Id", villainId);

            object villainNameObject = await getVillainNameCommand.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand villainMinionsInfoCommand = new SqlCommand
                (Queries.VILLAIN_MINIONS_INFO_BY_ID, sqlConnection);
            villainMinionsInfoCommand.Parameters.AddWithValue("Id", villainId);

            SqlDataReader sqlDataReader =
                await villainMinionsInfoCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                Console.WriteLine($"Villain: {villainName}");

                if (!sqlDataReader.HasRows)
                {
                    //There are no minions ofr given villain
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        long rowNumber = sqlDataReader.GetInt64(0);
                        string minionName = sqlDataReader.GetString(1);
                        int minionAge = sqlDataReader.GetInt32(2);

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }

        //Problem 04
        private static async Task AddMinionAsync
            (SqlConnection sqlConnection, string minionName, int minionAge, string townName, string villainName)
        {
            SqlCommand getTownIdCmd = new SqlCommand
                (Queries.ID_BY_TOWN_NAME, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("townName", townName);

            object townIdObject = await getTownIdCmd.ExecuteScalarAsync();
            if (townIdObject == null)
            {
                SqlCommand insertTownCommad = new SqlCommand
                    (Queries.INSERT_TOWN, sqlConnection);

                insertTownCommad.Parameters.AddWithValue("townName", townName);

                int rowsAffectedTowns = await insertTownCommad.ExecuteNonQueryAsync();

                if (rowsAffectedTowns == 0)
                {
                    Console.WriteLine("Problem occured while inserting new town into the database MinionsDB! Please, try again later!");
                    return;
                }

                townIdObject = await getTownIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Town {townName} was added to the database.");
            }

            int townId = (int)townIdObject;

            SqlCommand getVillainIdCmd = new SqlCommand
                (Queries.ID_BY_VILLAIN_NAME, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("Name", villainName);

            object villainIdObject = await getVillainIdCmd.ExecuteScalarAsync();
            if (villainIdObject == null)
            {
                SqlCommand insertVillainCmd = new SqlCommand
                    (Queries.INSERT_VILLAINS, sqlConnection);
                insertVillainCmd.Parameters.AddWithValue("villainName", villainName);

                int rowsAffectedVillains = await insertVillainCmd.ExecuteNonQueryAsync();

                if (rowsAffectedVillains == 0)
                {
                    Console.WriteLine("Problem occured while inserting new villain into the database MinionsDB! Please, try again later!");
                    return;
                }

                villainIdObject = await getVillainIdCmd.ExecuteScalarAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)villainIdObject;

            SqlCommand insertMinionCommand = new SqlCommand
                (Queries.INSERT_MINION, sqlConnection);
            insertMinionCommand.Parameters.AddWithValue("name", minionName);
            insertMinionCommand.Parameters.AddWithValue("age", minionAge);
            insertMinionCommand.Parameters.AddWithValue("townId", townId);

            int rowsAffected = await insertMinionCommand.ExecuteNonQueryAsync();
            if (rowsAffected == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion into the database MinionsDB! Please, try again later!");
                return;
            }

            SqlCommand getMinionIdCommand = new SqlCommand
                (Queries.ID_BY_MINION_NAME, sqlConnection);
            getMinionIdCommand.Parameters.AddWithValue("name", minionName);

            int minionId = (int)await getMinionIdCommand.ExecuteScalarAsync();

            SqlCommand insertMinionVillainCommand = new SqlCommand
                (Queries.INSERT_MINION_VILLAIN, sqlConnection);
            insertMinionVillainCommand.Parameters.AddWithValue("villainId", villainId);
            insertMinionVillainCommand.Parameters.AddWithValue("minionId", minionId);

            int rowsAffectedMV = await insertMinionVillainCommand.ExecuteNonQueryAsync();
            if (rowsAffectedMV == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion under the cotrol of the given villain! Please, try again later!");
                return;
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}