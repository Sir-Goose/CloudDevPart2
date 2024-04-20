using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers;

public class LoginController : Controller
{
    private readonly LoginModel _login;

    public LoginController()
    {
        _login = new LoginModel();
    }

    [HttpPost]
    public ActionResult Login(string email, string name)
    {
        var loginModel = new LoginModel();
        var userId = LoginModel.SelectUser(email, name);
        if (userId != -1)
            return RedirectToAction("Products", "Home", new { userID = userId });
        return View("Index");
    }
}