using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using F1.Models;

namespace F1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RacingDriver>()
                .HasOne(p => p.Team)
                .WithMany(b => b.RacingDrivers)
                .HasForeignKey(p => p.TeamID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RacingDriver>()
                .HasOne(p => p.Nationality)
                .WithMany(b => b.RacingDrivers)
                .HasForeignKey(p => p.NationalityID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>()
                .HasOne(p => p.Nationality)
                .WithMany(b => b.Teams)
                .HasForeignKey(p => p.NationalityID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nationality>()
                .HasMany(p => p.RacingDrivers)
                .WithOne(b => b.Nationality)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nationality>()
                .HasMany(p => p.Teams)
                .WithOne(b => b.Nationality)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>()
                .HasMany(p => p.RacingDrivers)
                .WithOne(b => b.Team)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<F1.Models.Nationality> Nationality { get; set; }

        public DbSet<F1.Models.Team> Team { get; set; }

        public DbSet<F1.Models.RacingDriver> RacingDriver { get; set; }
    }
}
