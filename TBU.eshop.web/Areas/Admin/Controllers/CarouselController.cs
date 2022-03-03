using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;
using TBU.eshop.web.Models.Infrastructure.Database;

namespace TBU.eshop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        public IActionResult Select()
        {
            IList<CarouselItem> carouselItems = DatabaseFake.CarouselItems;

            return View(carouselItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarouselItem carouselItem)
        {
            DatabaseFake.CarouselItems.Add(carouselItem);

            return RedirectToAction(nameof(Select));
        }
    }
}
