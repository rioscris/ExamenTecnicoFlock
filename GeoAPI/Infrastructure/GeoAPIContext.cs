using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace Infrastructure
{
    public class GeoAPIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public GeoAPIContext(DbContextOptions<GeoAPIContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasData(new User { Username = "admin" }); 
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Username);
            builder.Entity<User>().Property(u => u.Username).HasMaxLength(20);
            builder.Entity<User>().Property(u => u.Password).IsRequired();
        }
    }
}
