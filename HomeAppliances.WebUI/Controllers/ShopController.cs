using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeAppliances.WebUI.Controllers
{
	[Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private IProductService _productService;
        private ICategoryDal _categoryService;
		private IBrandDal _brandService;
        private ICardService _cardService;
        private ICardItemService _cardItemService;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(IProductService productService, ICategoryDal categoryService, IBrandDal brandService, ICardService cardService, ICardItemService cardItemService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _cardService = cardService;
            _cardItemService = cardItemService;
            _userManager = userManager;
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
		public async Task<IActionResult> Detail(int id)
		{
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = value.Id;

            var result = _cardService.GetCardByUserID(userId.ToString());
            var cardId = result.Id;
            ViewBag.cardId = Convert.ToInt32(cardId);

            return View(new ProductCardItemViewModel()
            {
                Product = _productService.GetProductDetails(id),
            });
        }
        [HttpPost]
        public async Task<IActionResult> Detail(ProductCardItemViewModel productCardItemViewModel)
        {
            CardItem createCardItem = new CardItem()
            {
                CardId = productCardItemViewModel.CardItem.CardId,
                ProductId = productCardItemViewModel.CardItem.ProductId,
                Quantity = productCardItemViewModel.CardItem.Quantity,
            };

            _cardItemService.TCreate(createCardItem);
            return RedirectToAction("Detail");
        }
    }
}
