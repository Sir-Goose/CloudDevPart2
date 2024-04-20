using System.Diagnostics;
using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Products(int userId)
    {
        var products = ProductTable.GetAllProducts();

        ViewData["Products"] = products;
        ViewData["UserID"] = userId;

        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult MyWork()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    public IActionResult Orders()
    {
        var orders = Transactions.GetAllOrders();

        ViewData["Orders"] = orders;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}