using HomeAppliances.Business.Abstract;
using HomeAppliances.Entity.Concrete;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeAppliances.WebUI.Controllers
{
	public class CheckoutController : Controller
	{
		private ICardItemService _cardItemService;
		private IAppUserService _appUserService;
		private readonly UserManager<AppUser> _userManager;
		private IOrderService _orderService;
		private IOrderItemService _orderItemService;
		private ICardService _cardService;

		public CheckoutController(ICardItemService cardItemService, IAppUserService appUserService, UserManager<AppUser> userManager, IOrderService orderService, IOrderItemService orderItemService, ICardService cardService)
		{
			_cardItemService = cardItemService;
			_appUserService = appUserService;
			_userManager = userManager;
			_orderService = orderService;
			_orderItemService = orderItemService;
			_cardService = cardService;
		}

		public async Task<IActionResult> Index()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			var userId = value.Id;

			return View(new CheckoutViewModel()
			{
				CardItems = _cardItemService.GetCardItemsWithProducts(),
				AppUser = _appUserService.TGetById(userId),
			});
		}
		[HttpPost]
		public async Task<IActionResult> Index(CheckoutViewModel checkoutViewModel)
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			var userId = value.Id;

			var cardItems = _cardItemService.GetCardItemsWithProducts();

			if (!ModelState.IsValid)
			{
				var order = new Order()
				{
					Name = checkoutViewModel.AppUser.Name,
					Surname = checkoutViewModel.AppUser.Surname,
					City = checkoutViewModel.Order.City,
					District = checkoutViewModel.Order.District,
					Address = checkoutViewModel.Order.Address,
					Email = checkoutViewModel.AppUser.Email,
					UserID = userId.ToString(),
					CreatedDate = DateTime.Now,
				};

				_orderService.Create(order);
				var orderid = _orderService.GetOrderByUserId(userId).OrderID;

				foreach (var item in cardItems)
				{
					var orderItem = new OrderItem()
					{
						OrderId = orderid,
						ProductId = item.Product.ProductID,
						Quantity = item.Quantity,
						Price = Convert.ToDecimal(item.Product.Price),
					};

					_orderItemService.TCreate(orderItem);
				}

				var cardid = _cardService.GetCardByUserID(userId.ToString()).Id;
				_cardService.ClearCard(cardid);

				return RedirectToAction("Index" ,"Home");
			}


			return View(new CheckoutViewModel()
			{
				CardItems = _cardItemService.GetCardItemsWithProducts(),
				AppUser = _appUserService.TGetById(userId),
			});
		}
	}
}
