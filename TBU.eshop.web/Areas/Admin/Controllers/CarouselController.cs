using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;
using TBU.eshop.web.Models.Entities.Identity;
using TBU.eshop.web.Models.Implementation;
using TBU.eshop.web.Models.Infrastructure.Database;

namespace TBU.eshop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment webHostEnvironment;
        public CarouselController(EshopDbContext eshopDB, IWebHostEnvironment webHostEnvironment)
        {
            eshopDbContext = eshopDB;
            this.webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(CarouselItem carouselItem)
        {

            FileUpload fileUpload = new FileUpload(webHostEnvironment.WebRootPath, "img/Carousels", "image");
            carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);

            ModelState.Clear();
            TryValidateModel(carouselItem);
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
        public async Task<IActionResult> Edit(CarouselItem carouselItem)
        {
            carouselItem.ImageSource = "-";
            if (carouselItem.Image != null)
            {
                FileUpload fileUpload = new FileUpload(webHostEnvironment.WebRootPath, "img/Carousels", "image");
                carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);
            }

            ModelState.Clear();
            TryValidateModel(carouselItem);
            if (ModelState.IsValid)
            {
                CarouselItem ci = eshopDbContext.CarouselItems.FirstOrDefault(carouselI => carouselI.ID == carouselItem.ID);
                if (ci != null)
                {
                    ci.ImageAlt = carouselItem.ImageAlt;
                    if (carouselItem.ImageSource != "-")
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
