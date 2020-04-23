using Microsoft.EntityFrameworkCore;
using ShortUrl.DataLayer.Mapping;
using ShortUrl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.DataLayer.Context
{
    public class MainContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ShortUrl;user id = sa;password=123;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ShortUrlMapping.RegisterAll(modelBuilder);
        }

        public DbSet<Url> Urls { get; set; }
    }
}
