﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework;

public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
{
    public SimpleTraderDbContext CreateDbContext(string[] args = null)
    {
        var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
        options.UseSqlServer("Server=(localdb)\\ProjectModels;Database=SimpleTraderDB;Trusted_Connection=True;");

        return new SimpleTraderDbContext(options.Options);
    }
}