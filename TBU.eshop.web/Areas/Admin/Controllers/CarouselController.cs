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
        readonly EshopDbContext eshopDbContext;
        public CarouselController(EshopDbContext eshopDB)
        {
            eshopDbContext = eshopDB;
        }


        public IActionResult Select()
        {
            IList<CarouselItem> carouselItems = eshopDbContext.CarouselItems.ToList();

            return View(carouselItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarouselItem carouselItem)
        {
            if (ModelState.IsValid)
            {
                eshopDbContext.CarouselItems.Add(carouselItem);

                eshopDbContext.SaveChanges();

                return RedirectToAction(nameof(Select));
            }
            else
            {
                return View(carouselItem);
            }
        }

        public IActionResult Edit(int ID)
        {
            CarouselItem ci = eshopDbContext.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == ID);
            if (ci != null)
            {
                return View(ci);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CarouselItem carouselItem)
        {
            if (ModelState.IsValid)
            {
                CarouselItem ci = eshopDbContext.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == carouselItem.ID);
                if (ci != null)
                {
                    ci.ImageAlt = carouselItem.ImageAlt;
                    ci.ImageSource = carouselItem.ImageSource;

                    eshopDbContext.SaveChanges();

                    return RedirectToAction(nameof(Select));
                }

                return NotFound();
            }
            else
            {
                return View(carouselItem);
            }
        }


        public IActionResult Delete(int ID)
        {
            CarouselItem ci = eshopDbContext.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == ID);
            if (ci != null)
            {
                eshopDbContext.CarouselItems.Remove(ci);

                eshopDbContext.SaveChanges();

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }
    }
}
