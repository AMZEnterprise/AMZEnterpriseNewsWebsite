using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PortalNewsMVC.Models.Domain
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=BloggingContext")
        {
        }

        public virtual DbSet<Categorye> Categoryes { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Gallerye> Galleryes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsLatter> NewsLatters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<SubCategorye> SubCategoryes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorye>()
                .HasMany(e => e.SubCategoryes)
                .WithRequired(e => e.Categorye)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<News>()
                .Property(e => e.NewsImage)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .HasMany(e => e.Galleryes)
                .WithRequired(e => e.News)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<News>()
                .HasMany(e => e.Tags)
                .WithRequired(e => e.News)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.News)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.LogUser);
        }
    }
}