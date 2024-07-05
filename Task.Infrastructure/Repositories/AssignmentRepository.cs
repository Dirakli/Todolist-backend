using System.Data;
using System.Data.SqlClient;
using Task.Domain.Abstract.Repositories;
using Task.Domain.Entities;
using Task.Domain.Enums;

namespace Task.Infrastructure.Repositories;

public class AssignmentRepository(string connectionString) : IAssignmentRepository
{
    private readonly string _connectionString = connectionString;

    public IEnumerable<Assignment> GetAll(AssignmentStatus status)
    {
        List<Assignment> assignments = [];

        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = new("GetAllTask", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@Status", status);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Assignment assignment = new()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()!,
                    Status = (AssignmentStatus)(int)reader["Status"]
                };
                assignments.Add(assignment);
            }
        }

        return assignments;
    }

    public void AddAssignment(Assignment model)
    {
        using SqlConnection connection = new(_connectionString);

        SqlCommand command = new("AddAssignment", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@Name", model.Name);
        command.Parameters.AddWithValue("@Status", (int)model.Status);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void UpdateAssignment(Assignment model)
    {
        using SqlConnection connection = new(_connectionString);

        SqlCommand command = new("UpdateAssignment", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@Id", model.Id);
        command.Parameters.AddWithValue("@Name", model.Name);
        command.Parameters.AddWithValue("@Status", (int)model.Status);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void DeleteAssignment(int Id)
    {
        using SqlConnection connection = new(_connectionString);

        SqlCommand command = new("DeleteAssignment", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@Id", Id);

        connection.Open();
        command.ExecuteNonQuery();
    }
}