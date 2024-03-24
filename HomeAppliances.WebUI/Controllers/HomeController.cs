using Microsoft.AspNetCore.Mvc;
using HomeAppliances.Business.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;

namespace HomeAppliances.WebUI.Controllers;

public class HomeController : Controller
{
    private IProductService _productService;
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }
    public IActionResult Index()
    {
        return View(new ProductListModel()
        {
            Products = _productService.GetAll()
        });

    }
}
