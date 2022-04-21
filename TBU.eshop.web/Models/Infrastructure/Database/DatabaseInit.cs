using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities;
using TBU.eshop.web.Models.Entities.Identity;

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

        public List<Role> GenerateRoles()
        {
            Role admin = new Role(Roles.Admin.ToString(), 1);
            Role manager = new Role(Roles.Manager.ToString(), 2);
            Role customer = new Role(Roles.Customer.ToString(), 3);
            List<Role> roles = new List<Role> { admin, manager, customer };
            return roles;
        }

        //uncomment and complete the following code after you create the entity: Product

        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            Product p1 = new Product()
            {
                ID = 1,
                ImageSource = "/img/Products/Chleb_100_zito_2.jpg",
                Name = "Bread",
                Description = "Yes, it is a bread.",
                Price = 25,
                Quantity = 50
            };
            Product p2 = new Product()
            {
                ID = 2,
                ImageSource = "/img/Products/thumb_260x340__masla-a-tuky.jpg",
                Name = "Butter",
                Description = "Delicious butter",
                Price = 45,
                Quantity = 10
            };
            Product p3 = new Product()
            {
                ID = 3,
                ImageSource = "/img/Products/produkty-home.png",
                Name = "Glass (200 ml)",
                Description = "Just for drink.",
                Price = 400,
                Quantity = 125
            };

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            return products;
        }

        public async Task EnsureAdminCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "admin",
                Email = "admin@admin.cz",
                EmailConfirmed = true,
                FirstName = "name",
                LastName = "last name"
            };
            string password = "aA1/";

            User adminInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (adminInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Admin: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureManagerCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "manager",
                Email = "manager@manager.cz",
                EmailConfirmed = true,
                FirstName = "name",
                LastName = "last name"
            };
            string password = "aA1/";

            User managerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (managerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role != Roles.Admin.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Manager: {error.Code}, {error.Description}");
                    }
                }
            }

        }
    }
}
