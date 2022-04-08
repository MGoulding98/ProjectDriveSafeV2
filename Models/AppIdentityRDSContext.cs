using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDriveSafeV2.Models
{
    // context for the login
    public class AppIdentityRDSContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityRDSContext(DbContextOptions options) : base(options)
        {

        }
            
    }
}
