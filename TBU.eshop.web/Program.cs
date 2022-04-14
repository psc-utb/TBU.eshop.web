using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities.Identity;
using TBU.eshop.web.Models.Infrastructure.Database;

namespace TBU.eshop.web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                DatabaseInit dbInit = new DatabaseInit();

                await dbInit.EnsureAdminCreated(userManager);
                await dbInit.EnsureManagerCreated(userManager);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
