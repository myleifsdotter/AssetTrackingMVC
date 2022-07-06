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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* seeding address data */
            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, StreetName = "Fina gatan", HouseNumber = "4", PostalCode = "21111", City = "Malmö", PhoneNumber = "+46 123 45 67 98" });
            modelBuilder.Entity<Address>().HasData(new Address { Id = 2, StreetName = "Calle Bonita", HouseNumber = "4", PostalCode = "33203", City = "Gijón", PhoneNumber = "+34 123 45 67 98" });
            modelBuilder.Entity<Address>().HasData(new Address { Id = 3, StreetName = "Posh Street", HouseNumber = "4", PostalCode = "32601", City = "Gainsville FL", PhoneNumber = "+1 123 45 67 98" });

            /* seeding office data */
            modelBuilder.Entity<Office>().HasData(new Office { Id = 1, Country = "Sweden", Currency = "SEK", AddressId = 1 });
            modelBuilder.Entity<Office>().HasData(new Office { Id = 2, Country = "Spain", Currency = "EUR", AddressId = 2 });
            modelBuilder.Entity<Office>().HasData(new Office { Id = 3, Country = "USA", Currency = "USD", AddressId = 3 });

            ///* seeding Asset data */
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, Type = "Mobile Phone", Brand = "iPhone", Model = "8", PurchaseDate = Convert.ToDateTime("2019-10-05"), Price = 970, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, Type = "Laptop Computer", Brand = "HP", Model = "Elitebook", PurchaseDate = Convert.ToDateTime("2022-05-01"), Price = 1423, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, Type = "Mobile Phone", Brand = "iPhone", Model = "11", PurchaseDate = Convert.ToDateTime("2022-04-25"), Price = 990, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, Type = "Mobile Phone", Brand = "iPhone", Model = "X", PurchaseDate = Convert.ToDateTime("2019-11-05"), Price = 1245, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, Type = "Mobile Phone", Brand = "Motorola", Model = "Razr", PurchaseDate = Convert.ToDateTime("2019-12-06"), Price = 970, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, Type = "Laptop Computer", Brand = "HP", Model = "Elitebook", PurchaseDate = Convert.ToDateTime("2019-08-07"), Price = 588, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, Type = "Laptop Computer", Brand = "Asus", Model = "W234", PurchaseDate = Convert.ToDateTime("2019-11-21"), Price = 1200, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, Type = "Laptop Computer", Brand = "Lenovo", Model = "Yoga 730", PurchaseDate = Convert.ToDateTime("2021-09-28"), Price = 835, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, Type = "Laptop Computer", Brand = "Lenovo", Model = "Yoga 530", PurchaseDate = Convert.ToDateTime("2019-11-21"), Price = 1030, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, Type = "Mobile Phone", Brand = "Samsung", Model = "Galaxy", PurchaseDate = Convert.ToDateTime("2018-06-06"), Price = 1170, OfficeId = 3 });

        }
    }
}