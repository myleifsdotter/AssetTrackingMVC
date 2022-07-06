using AssetTrackingMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}