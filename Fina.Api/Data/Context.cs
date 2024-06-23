﻿using Fina.Api.Data.Mapping;
using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
        }
    }
}
