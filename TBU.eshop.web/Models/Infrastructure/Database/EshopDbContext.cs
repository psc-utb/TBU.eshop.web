using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;

namespace TBU.eshop.web.Models.Infrastructure.Database
{
    public class EshopDbContext : DbContext
    {
        public DbSet<CarouselItem> CarouselItems { get; set; }

        public EshopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            DatabaseInit init = new DatabaseInit();
            modelBuilder.Entity<CarouselItem>().HasData(init.GenerateCarouselItems());
        }
    }
}
