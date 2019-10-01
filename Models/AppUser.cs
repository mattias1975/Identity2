
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Migrations;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.AspNetCore.Identity

{
    public class AppUser : IdentityUser
    {
        public int Usernumber { get; set; }
        public string Name { get; set; }
        public List<People> People { get; set; }
    }


}
