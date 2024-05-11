using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAppliances.WebUI.Controllers
{
	[Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private IProductService _productService;
        private ICategoryDal _categoryService;
		private IBrandDal _brandService;


		public ShopController(IProductService productService, ICategoryDal categoryService, IBrandDal brandService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_brandService = brandService;
		}

		[Route("Shop/Index/{ProductCategory?}/{brand?}")]
		public IActionResult Index(int? ProductCategory, string? brand)
        {
			ProductListModel model = new ProductListModel();

			if ((ProductCategory != null) && (brand != null))
            {
				model.Products = _productService.GetProductsByCategoryId(ProductCategory)
					.Where(i => i.Brand.Name.ToLower() == brand.ToLower())
					.ToList();
				model.Brands = _brandService.GetAll();
				model.ProductCategories = _categoryService.GetAll();


				return View(model);
			}
			else if((ProductCategory == null) && (brand != null))
			{
				model.Products = _productService.GetProductsWithBrand()
					.Where(i => i.Brand.Name.ToLower() == brand.ToLower())
					.ToList();
				model.Brands = _brandService.GetAll();
				model.ProductCategories = _categoryService.GetAll();

				return View(model);
			}
			else if ((ProductCategory != null) && (brand == null))
			{
				model.Products = _productService.GetProductsByCategoryId(ProductCategory);
				model.Brands = _brandService.GetAll();
				model.ProductCategories = _categoryService.GetAll();

				return View(model);
			}
			else 
            {
				model.Products = _productService.GetAll();
				model.Brands = _brandService.GetAll();
				model.ProductCategories = _categoryService.GetAll();
				
				return View(model);
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
