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

        public IActionResult Edit(int ID)
        {
            CarouselItem ci = DatabaseFake.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == ID);
            if (ci != null)
            {
                return View(ci);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CarouselItem carouselItem)
        {
            CarouselItem ci = DatabaseFake.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == carouselItem.ID);
            if (ci != null)
            {
                ci.ImageAlt = carouselItem.ImageAlt;
                ci.ImageSource = carouselItem.ImageSource;

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }


        public IActionResult Delete(int ID)
        {
            CarouselItem ci = DatabaseFake.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == ID);
            if (ci != null)
            {
                DatabaseFake.CarouselItems.Remove(ci);

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }
    }
}
