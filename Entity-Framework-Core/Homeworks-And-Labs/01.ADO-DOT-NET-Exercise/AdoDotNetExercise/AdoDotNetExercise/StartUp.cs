using Microsoft.Data.SqlClient;
using P02.VillainNames;
using System.Text;

namespace AdoDotNetExercise
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            await sqlConnection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string result = await GetVillainWithAllMinionsByIdASync(sqlConnection, villainId);

            Console.WriteLine(result); 
        }

        // Problem 02
        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinionsAsync, sqlConnection);

            // One row with many columns
            // First the reader hasn't loaded any data. We must call Read() first!
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            // No more data
            return sb.ToString().Trim();
        } 

        // Problem 03

        static async Task<string> GetVillainWithAllMinionsByIdASync(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            // SQL Injection Prevention -> Using SqlParameters
            // One row with one column
            SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);

            getVillainNameCommand.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCommand.ExecuteScalarAsync();

            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            // Use sql parameters
            // ExecuteReader() -> Many rows with many columns
            SqlCommand getAllMinionsCommand = new SqlCommand(SqlQueries.GetAllMinionsByVillainId, sqlConnection);

            getAllMinionsCommand.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader minionsReader = await getAllMinionsCommand.ExecuteReaderAsync();

            sb.AppendLine($"Villain: {villainName}");

            if (!minionsReader.HasRows)
            {
                sb.AppendLine("no minions");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNumber = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().Trim();
        }
}