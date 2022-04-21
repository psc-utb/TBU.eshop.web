﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBU.eshop.web.Models.Entities
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageSource { get; set; }


    }
}
