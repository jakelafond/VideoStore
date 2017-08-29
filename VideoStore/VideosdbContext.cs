using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VideoStore.Models;

namespace VideoStore
{
    public partial class VideosdbContext : DbContext
    {
        public DbSet<MovieModel> Movie {get;set;}
        public DbSet<GenreModel> Genre {get;set;}
        public DbSet<CustomerModel> Customer {get;set;}
        public DbSet<RentalRecordModel> RentalRecord {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=Videosdb;Username=dev;Password=mintek0519");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
