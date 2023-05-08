
using Medium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.DAL
{
    internal class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CA-R215-PC07\SQLEXPRESS;Database=MediumDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(model =>
            {
                model.HasKey(prop => prop.Id);
                model.Property(prop => prop.Title).HasMaxLength(20).IsRequired(true);
                model.Property(prop => prop.AuthorId).IsRequired(true);  //not null
            });
            modelBuilder.Entity<Topic>(model =>
            {
                model.HasKey(prop => prop.Id);
                model.Property(prop => prop.Title).HasMaxLength(20).IsRequired(true);
                model.Property(prop => prop.ParentTopicId).IsRequired(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
