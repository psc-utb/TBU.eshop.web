using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;

namespace TBU.eshop.web.Models.Infrastructure.Database
{
    public class DatabaseInit
    {
        public List<CarouselItem> GenerateCarouselItems()
        {
            List<CarouselItem> carouselItems = new List<CarouselItem>();
            CarouselItem ci1 = new CarouselItem()
            {
                ID = 1,
                ImageSource = "/img/Information-Technology.jpg",
                ImageAlt = "First slide"
            };
            CarouselItem ci2 = new CarouselItem()
            {
                ID = 2,
                ImageSource = "/img/Information-Technology-1.jpg",
                ImageAlt = "Second slide"
            };
            CarouselItem ci3 = new CarouselItem()
            {
                ID = 3,
                ImageSource = "/img/IT.jpeg",
                ImageAlt = "Third slide"
            };
            CarouselItem ci4 = new CarouselItem()
            {
                ID = 4,
                ImageSource = "/img/bits-e1611847851285-1440x810.jpeg",
                ImageAlt = "Fourth slide"
            };

            carouselItems.Add(ci1);
            carouselItems.Add(ci2);
            carouselItems.Add(ci3);
            carouselItems.Add(ci4);

            return carouselItems;
        }

        //uncomment and complete the following code after you create the entity: Product
        /*
        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();
            Product p1 = new Product()
            {
                ID = 0,
                //insert your code ...
            };
            Product p2 = new Product()
            {
                ID = 1,
                //insert your code ...
            };
            Product p3 = new Product()
            {
                ID = 2,
                //insert your code ...
            };
            Product p4 = new Product()
            {
                ID = 3,
                //insert your code ...
            };
            Product p5 = new Product()
            {
                ID = 4,
                //insert your code ...
            };

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);

            return products;
        }*/
    }
}
