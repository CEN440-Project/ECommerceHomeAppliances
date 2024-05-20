using Microsoft.AspNetCore.Mvc;
using HomeAppliances.Business.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeAppliances.WebUI.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private IProductService _productService;
		public HomeController(IProductService productService)
		{
			_productService = productService;
		}
		public IActionResult Index()
		{

			var products = _productService.GetAll().Take(4).ToList();

			return View(products);

		}
	}
}