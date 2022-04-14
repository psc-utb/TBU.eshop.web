using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBU.eshop.web.Models.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {

        }

        public Role(string name, int id) : base(name)
        {
            Id = id;
            NormalizedName = name.ToUpper();
        }
    }
}
