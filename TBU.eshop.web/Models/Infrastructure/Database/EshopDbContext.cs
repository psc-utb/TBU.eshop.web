using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;
using TBU.eshop.web.Models.Entities.Identity;

namespace TBU.eshop.web.Models.Infrastructure.Database
{
    public class EshopDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<CarouselItem> CarouselItems { get; set; }

        public EshopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit init = new DatabaseInit();
            modelBuilder.Entity<CarouselItem>().HasData(init.GenerateCarouselItems());
            modelBuilder.Entity<Role>().HasData(init.GenerateRoles());
        }
    }
}
