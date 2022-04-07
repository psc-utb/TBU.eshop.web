using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.ApplicationServices.Abstraction;

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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            //
            return View(nameof(Login));
        }
    }
}
