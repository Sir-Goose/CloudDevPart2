using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers;

public class UserController : Controller
{
    private UserTable _usrtbl = new();


    [HttpPost]
    public ActionResult SignUp(UserTable users)
    {
        var result = _usrtbl.insert_User(users);
        return RedirectToAction("Products", "Home");
    }

    [HttpGet]
    public ActionResult SignUp()
    {
        return View(_usrtbl);
    }
}