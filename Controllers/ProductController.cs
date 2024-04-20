using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers;

public class ProductController : Controller
{
    private ProductTable _productTable = new();


    [HttpPost]
    public ActionResult InsertProducts(ProductTable products)
    {
        var result2 = _productTable.insert_product(products);
        return RedirectToAction("Products", "Home");
    }

    [HttpGet]
    public ActionResult InsertProducts()
    {
        return View(_productTable);
    }
}