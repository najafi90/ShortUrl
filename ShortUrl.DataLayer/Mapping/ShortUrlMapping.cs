using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShortUrl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.DataLayer.Mapping
{
    public static class ShortUrlMapping
    {
        internal static void RegisterAll(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlConfiguration());
        }

        private class UrlConfiguration : IEntityTypeConfiguration<Url>
        {
            public void Configure(EntityTypeBuilder<Url> builder)
            {
                builder.Property(o => o.MainUrlAddress).HasMaxLength(1024);
                builder.Property(o => o.ShortAddress).HasMaxLength(64);
                builder.HasIndex(o => o.ShortAddress).IsUnique();
            }
        }
    }
}
