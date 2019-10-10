using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class AppUser : IdentityUser
    {
        public int UserNumber { get; set; }
       
    }
}
