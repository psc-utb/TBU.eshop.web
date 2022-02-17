using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;

namespace TBU.eshop.web.Models
{
    public class IndexViewModel
    {
        public IList<CarouselItem> CarouselItems { get; set; }
        //public IList<Product> Products { get; set; }
    }
}
