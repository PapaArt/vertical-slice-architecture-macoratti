﻿using Microsoft.EntityFrameworkCore;
using Vertical_Slice_Architecture.Domain;

namespace Vertical_Slice_Architecture.Infrastructure.Context
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}