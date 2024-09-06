
using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;Trusted_Connection=True;Trust Server Certificate = true;");

connection.Open();  // We have to explicitly open the connection

//using (connection) // The using and iDisposable will automatically close the connection
//{
//    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
//    int employeesCount = (int) await command.ExecuteScalarAsync();

//    Console.WriteLine($"There are {employeesCount} employees in our company");
//}


// Data Reader
using (connection) // The using and iDisposable will automatically close the connection
{
    SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE DepartmentID = 7", connection);
    SqlDataReader reader = await command.ExecuteReaderAsync();

    using (reader)
    {
        while (reader.Read())
        {
            string? firstName = reader["FirstName"]?.ToString();
            string? lastName = reader[2]?.ToString();

            Console.WriteLine($"{firstName} {lastName}");
        }
    }
}
