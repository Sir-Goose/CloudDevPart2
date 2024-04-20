using System.Data.SqlClient;

namespace CloudDevelopment.Models;

public class UserTable
{
    public static string ConString = Program.GetConnectionString();
    public static SqlConnection Con = new(ConString);


    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }


    public int insert_User(UserTable m)
    {
        try
        {
            const string sql = "INSERT INTO Users (UserID, FirstName, LastName, Email) VALUES (@UserID, @FirstName, @LastName, @Email)";
            var cmd = new SqlCommand(sql, Con);
            var random = new Random();
            var randomNumber = random.Next(1, 1001);
            cmd.Parameters.AddWithValue("@UserID", randomNumber);
            cmd.Parameters.AddWithValue("@FirstName", m.FirstName);
            cmd.Parameters.AddWithValue("@LastName", m.LastName);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            Con.Open();
            var rowsAffected = cmd.ExecuteNonQuery();
            Con.Close();
            return rowsAffected;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            // For now, rethrow the exception
            throw ex;
        }
    }
}