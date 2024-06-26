﻿using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).IsRequired(true).HasColumnType("VARCHAR").HasMaxLength(160);
            builder.Property(c => c.Description).IsRequired(false).HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(c => c.UserId).IsRequired(true).HasColumnType("VARCHAR").HasMaxLength(160);

        }
    }
}
