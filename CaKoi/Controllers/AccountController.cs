using CaKoi.Entities;
using CaKoi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CaKoi.Controllers
{
	public class AccountController : Controller
	{
		public readonly ChamsoccakoiContext _dbContext;

		public AccountController(ChamsoccakoiContext dbContext)
		{
			_dbContext = dbContext;
        }

        public IActionResult Login(FormLoginViewModel form)
		{ 
            if (form == null)
			{
				return View();
			} else
			{
                ViewData["ErrorMessage"] = "";
                string username = form.username;
				string password = form.password;

				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
                    ViewData["ErrorMessage"] = "Username hoac password bi trong";
				} else
				{
                    User loginUser = _dbContext.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

                    if (loginUser == null)
                    {
						ViewData["ErrorMessage"] = "Sai username hoac mat khau";
                        return View();
                    }
                    else
                    {
                        // user is loggin in
                        var isLoggedIn = true;
						return RedirectToAction("Index", "Home");
                    }
                }

                return View();
            }
		}

		public IActionResult Logout()
		{
			//
			return null;
		}
	}
}
