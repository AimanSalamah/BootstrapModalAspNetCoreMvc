using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BootstrapModalAspNetCoreMvc.Models;

namespace BootstrapModalAspNetCoreMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BootstrapModalAspNetCoreMvc.Models.Products> Products { get; set; }
    }
}
