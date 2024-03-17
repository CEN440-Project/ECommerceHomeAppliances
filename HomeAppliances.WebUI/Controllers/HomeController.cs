using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeAppliances.WebUI.Models;

namespace HomeAppliances.WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
