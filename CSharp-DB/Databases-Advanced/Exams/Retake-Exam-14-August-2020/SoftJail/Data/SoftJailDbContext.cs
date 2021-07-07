﻿namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cell> Cells { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Officer> Officers { get; set; }

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>()
                .HasKey(x => new { x.PrisonerId, x.OfficerId });

            builder.Entity<OfficerPrisoner>(x =>
            {
                x.HasOne(p => p.Prisoner)
                .WithMany(po => po.PrisonerOfficers)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(o => o.Officer)
                .WithMany(op => op.OfficerPrisoners)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}