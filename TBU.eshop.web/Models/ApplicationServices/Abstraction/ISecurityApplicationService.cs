﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TBU.eshop.web.Models.Entities.Identity;
using TBU.eshop.web.Models.ViewModel;

namespace TBU.eshop.web.Models.ApplicationServices.Abstraction
{
    public interface ISecurityApplicationService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
        Task<User> FindUserByUsername(string username);
        Task<User> FindUserByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
        Task<User> GetCurrentUser(ClaimsPrincipal principal);

    }
}
