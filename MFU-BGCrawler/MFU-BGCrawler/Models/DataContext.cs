﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MFU_BGCrawler.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<Boardgame> Boardgame { get; set; }
        public DbSet<Boardgame> Country { get; set; }
        public DbSet<Boardgame> Currency { get; set; }
        public DbSet<Boardgame> ExchangeRate { get; set; }
        public DbSet<Store> Store { get; set; }

    }
}