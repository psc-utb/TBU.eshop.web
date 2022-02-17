using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;

namespace TBU.eshop.web.Models.Infrastructure.Database
{
    public static class DatabaseFake
    {
        public static List<CarouselItem> CarouselItems { get; set; }
        //uncomment the following code after you create the entity: Product
        //public static List<Product> Products { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            CarouselItems = dbInit.GenerateCarouselItems();
            //uncomment the following code after you create the entity: Product
            //Products = dbInit.GenerateProducts();
        }
    }
}
