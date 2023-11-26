using System;
using Microsoft.EntityFrameworkCore;
using ZeroHunger.Models;

namespace ZeroHunger.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<CollectRequest> CollectRequest { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary key
            modelBuilder.Entity<Admin>()
                .HasKey(e => e.adminUsername);

            modelBuilder.Entity<Applicants>()
                .HasKey(e => e.email);

            modelBuilder.Entity<CollectRequest>()
                .HasKey(e => e.reqId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.empUserName);

            modelBuilder.Entity<Restaurant>()
                .HasKey(e => e.restUserName);

            ////unique key
            //modelBuilder.Entity<Applicants>()
            //    .HasIndex(e => e.email)
            //    .IsUnique();

            //modelBuilder.Entity<Employee>()
            //    .HasIndex(e => e.empUserName)
            //    .IsUnique();

            //modelBuilder.Entity<Restaurant>()
            //    .HasIndex(e => e.restUserName)
            //    .IsUnique();

            ////dateTime
            //modelBuilder.Entity<Applicants>()
            //   .Property(e => e.applyDate)
            //   .HasColumnType("date")
            //   .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<Employee>()
            //  .Property(e => e.joinningDate)
            //  .HasColumnType("date")
            //  .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<CollectRequest>()
            //  .Property(e => e.reqPosted)
            //  .HasColumnType("date")
            //  .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<Restaurant>()
            //  .Property(e => e.registratineDate)
            //  .HasColumnType("date")
            //  .HasDefaultValueSql("GETDATE()");

            //relationship
            modelBuilder.Entity<CollectRequest>()
                .HasOne(fr => fr.Restaurant)
                .WithMany(r => r.CollectRequest)
                .HasForeignKey(fr => fr.restUserName)
                .IsRequired();

            //modelBuilder.Entity<CollectRequest>()
            //    .HasOne(e => e.Employee)
            //    .WithMany(u => u.CollectRequest)
            //    .HasForeignKey(e => e.empUsername);
            //    .IsRequired();

            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Applicants)
            //    .WithOne(u => u.Employee)
            //    .HasForeignKey<Employee>(e => e.email)
            //    .IsRequired();
        }
    }
}
