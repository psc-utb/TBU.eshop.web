using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.ApplicationServices.Abstraction;
using TBU.eshop.web.Models.ViewModel;

namespace TBU.eshop.web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        ISecurityApplicationService securityService;

        public AccountController(ISecurityApplicationService securityService)
        {
            this.securityService = securityService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                string[] errors = await securityService.Register(registerVM, Models.Entities.Identity.Roles.Customer);

                if (errors == null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password,
                        LoginFailed = false
                    };

                    bool success = await securityService.Login(loginVM);
                    if (success)
                    {
                        return RedirectToAction("Index", "Home", new { area = String.Empty });
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
            }

            return View(registerVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool success = await securityService.Login(loginVM);

                if (success)
                {
                    return RedirectToAction("Index", "Home", new { area = String.Empty });
                }
                loginVM.LoginFailed = true;
            }

            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await securityService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}
