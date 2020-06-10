using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GC_Car_Dealership_Capstone.Models;

namespace GC_Car_Dealership_Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GC_Car_Dealership_Capstone.Models.FavoriteCars> FavoriteCars { get; set; }
    }
}
