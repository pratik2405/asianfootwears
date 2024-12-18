﻿using Asian_Shoe.Models;
using Microsoft.EntityFrameworkCore;

namespace Asian_Shoe.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>op):base(op)
        {
            
        }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart>Carts { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseDetails> PurchasesDetails { get;set; }

        public DbSet<Status>Statuses { get; set; }

        public DbSet<Role>Roles { get; set;}
    }
}
