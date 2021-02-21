﻿using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Authors> Authors { get; set; }
    }
}
