using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TBU.eshop.web.Models.ApplicationServices.Abstraction;
using TBU.eshop.web.Models.Entities.Identity;
using TBU.eshop.web.Models.ViewModel;

namespace TBU.eshop.web.Models.ApplicationServices.Implementation
{
    public class SecurityIdentityApplicationService : ISecurityApplicationService
    {
        UserManager<User> userManager;
        SignInManager<User> sigInManager;

        public SecurityIdentityApplicationService(UserManager<User> userManager, SignInManager<User> sigInManager)
        {
            this.userManager = userManager;
            this.sigInManager = sigInManager;
        }

        public Task<User> FindUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }

        public Task<IList<string>> GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        public async Task<bool> Login(LoginViewModel vm)
        {
            //var result = await sigInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberMe, true);
            //return result.Succeeded;
            return true;
        }

        public Task Logout()
        {
            return sigInManager.SignOutAsync();
        }

        public async Task<string[]> Register(RegisterViewModel vm, Roles role)
        {
            //User user = new User()
            //{
            //    UserName = vm.Username,
            //    FirstName = vm.FirstName,
            //    LastName = vm.LastName,
            //    Email = vm.Email,
            //    PhoneNumber = vm.PhoneNumber
            //};

            //string[] errors = null;
            //var result = await userManager.CreateAsync(user, vm.Password);
            //if (result.Succeeded)
            //{
            //    var resultRole = await userManager.AddToRoleAsync(user, role.ToString());

            //    if (resultRole.Succeeded == false)
            //    {
            //        for (int i = 0; i < result.Errors.Count(); ++i)
            //            result.Errors.Append(result.Errors.ElementAt(i));
            //    }
            //}

            //if (result.Errors != null && result.Errors.Count() > 0)
            //{
            //    errors = new string[result.Errors.Count()];
            //    for (int i = 0; i < result.Errors.Count(); ++i)
            //    {
            //        errors[i] = result.Errors.ElementAt(i).Description;
            //    }
            //}

            //return errors;

            return null;
        }
    }
}
