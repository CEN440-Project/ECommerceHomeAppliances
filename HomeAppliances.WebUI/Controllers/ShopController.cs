using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAppliances.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        private ICategoryDal _categoryService;

		public ShopController(IProductService productService, ICategoryDal categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		public IActionResult Index(int? id)
        {
            if (!(id == null))
            {
				return View(new ProductListModel()
				{
					Products = _productService.GetProductsByCategoryId(id),
					SelectedCategory = RouteData.Values["category"]?.ToString(),
					ProductCategories = _categoryService.GetAll()
				});
			}
            else 
            {
				return View(new ProductListModel()
				{
					Products = _productService.GetAll(),
					ProductCategories = _categoryService.GetAll()
				});
			}
        }
		public IActionResult Detail(int id)
		{
			Product product = new Product();
			product = _productService.GetProductDetails(id);

			return View(product);
		}
    }
}
