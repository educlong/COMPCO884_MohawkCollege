using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureSite_aspNetCoreWebApp_ModelViewControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureSite_aspNetCoreWebApp_ModelViewControl.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
