using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        // Connection string
        string connString = "Host=localhost;Port=5432;Username=postgres;Password=lamis;Database=lamisplus";

        // Connect to PostgreSQL
        using (var conn = new NpgsqlConnection(connString))
        {
            try
            {
                // Open connection
                conn.Open();
                Console.WriteLine("Connected to PostgreSQL!");

                // Create a SQL command
                string sql = "SELECT first_name, surname FROM patient_person";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    // Execute the command and read the data
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"FirstName: {reader["first_name"]}, SurName: {reader["surname"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

