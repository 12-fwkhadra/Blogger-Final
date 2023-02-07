using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace AFK.Models
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options) : base(options)
        { }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserCategory> userCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCategory>()
            .HasKey(b => new { b.Id, b.categoryId });

            modelBuilder.Entity<UserCategory>()
            .HasOne(b => b.User)
            .WithMany(bb => bb.userCategories).HasForeignKey(b => b.Id);

            modelBuilder.Entity<UserCategory>()
            .HasOne(b => b.Category)
            .WithMany(bb => bb.userCategories).HasForeignKey(b => b.categoryId);

         
            modelBuilder.Entity<Question>().HasOne(b => b.category)
                    .WithMany(g => g.questions);
            modelBuilder.Entity<Question>().HasOne(b => b.user)
                    .WithMany(g => g.questions);

            modelBuilder.Entity<Answer>().HasOne(b => b.question)
                        .WithMany(g => g.answers);
            modelBuilder.Entity<Answer>().HasOne(b => b.user)
                        .WithMany(g => g.answers);
                        modelBuilder.ApplyConfiguration(new SeedCategory());
            // modelBuilder.Entity<Category>().HasData(new Category
            //     {
            //         categoryId = 1,
            //      categoryName = "math"
            //     },
            // new Category
            // {
            //     categoryId = 2,
            //     categoryName = "programming"
            // },
            // new Category
            // {
            //     categoryId = 3,
            //     categoryName = "books"
            // },
            // new Category
            // {
            //     categoryId = 4,
            //     categoryName = "pets"
            // },
            // new Category
            // {
            //     categoryId = 5,
            //     categoryName = "gaming"
            // },new Category
            // {
            //     categoryId = 6,
            //     categoryName = "politics"
            // },new Category
            // {
            //     categoryId = 7,
            //     categoryName = "gaming"
            // });





        }


    }
}
