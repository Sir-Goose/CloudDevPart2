using System.Data.SqlClient;

namespace CloudDevelopment.Models;

public class LoginModel
{
    private static readonly string ConString = Program.GetConnectionString();

    public static int SelectUser(string email, string name)
    {
        var userId = -1; // Default value if user is not found
        using var con = new SqlConnection(ConString);
        const string sql = "SELECT userID FROM Users WHERE Email = @Email AND FirstName = @Name";
        var cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Name", name);
        try
        {
            con.Open();
            var result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value) userId = Convert.ToInt32(result);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            // For now, rethrow the exception
            throw ex;
        }

        return userId;
    }
}