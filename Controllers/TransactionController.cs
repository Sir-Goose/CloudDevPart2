using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers;

public class TransactionController : Controller
{
    [HttpPost]
    public ActionResult PlaceOrder(int userId, int productId, int price)
    {
        try
        {
            var conString = Program.GetConnectionString();
            Console.WriteLine(userId);
            Console.WriteLine(productId);
            var con = new SqlConnection(conString);
            var sql =
                "INSERT INTO Transactions (TransactionID, UserID, ProductID, TransactionDate, Quantity, TotalAmount) VALUES (@TransactionID, @UserID, @ProductID, @TransactionDate, @Quantity, @TotalAmount)";

            var cmd = new SqlCommand(sql, con);
            {
                var random = new Random();
                var randomNumber = random.Next(1, 1001);

                cmd.Parameters.AddWithValue("@TransactionID", randomNumber);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@TotalAmount", price);
                cmd.Parameters.AddWithValue("Quantity", 1);
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                con.Open();

                var rowsAffected = cmd.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                    return RedirectToAction("Orders", "Home");
                return View("Orders");
            }
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }
}