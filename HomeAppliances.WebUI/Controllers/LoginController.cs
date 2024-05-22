using HomeAppliances.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HomeAppliances.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using HomeAppliances.Business.Abstract;
using HomeAppliances.Data.Abstract;

namespace HomeAppliances.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		//sisteme authentic olmak için:
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ICardDal _cardService;

		//ctor:usermanager'a atama işlemi yapmak için(iki ctoru birleştirdik altta)
		//public LoginController(UserManager<AppUser> userManager)
		//{
		//	_userManager = userManager;
		//}

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICardDal cardService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_cardService = cardService;
		}



		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel p) //identity'e ait işlemler yapacagımız için metodun async olması gerekir.
		{
			AppUser appUser = new AppUser()
			{
				Name = p.Name,
				Surname = p.Surname,
				Email = p.Mail,
				UserName = p.Username,
				ImageUrl = "x"
			};
			if (p.Password == p.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, p.Password);
				if (result.Succeeded)
				{
					var userid = await _userManager.GetUserIdAsync(appUser);
					_cardService.Create(new Card() { UserID = userid });

					return RedirectToAction("SignIn", "Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
                    }
				}
			}
			return View(p);
		}



		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					return RedirectToAction("SignIn", "Login");
                }
			}
			return View();
		}

		////logout
		//[HttpGet]
		//public async Task<IActionResult> LogOut()
		//{
		//	await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		//	return RedirectToAction("SignIn", "Login");
		//}
	}
}
