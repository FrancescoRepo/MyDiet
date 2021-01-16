using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDiet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDiet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DietMeal>().HasKey(dm => new { dm.DietId, dm.MealId });
            builder.Entity<MealProduct>().HasKey(mp => new { mp.MealId, mp.ProductId });
        }

        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietMeal> DietMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Weight> Weights { get; set; }
    }
}
