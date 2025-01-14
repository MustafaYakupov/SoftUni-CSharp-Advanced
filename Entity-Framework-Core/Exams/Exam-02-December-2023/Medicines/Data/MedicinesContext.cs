﻿namespace Medicines.Data;

using Medicines.Data.Models;
using Microsoft.EntityFrameworkCore;
public class MedicinesContext : DbContext
{
    public MedicinesContext()
    {
    }

    public MedicinesContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Medicine> Medicines { get; set; } = null!;

    public DbSet<Patient> Patients { get; set; } = null!;

    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;

    public DbSet<PatientMedicine> PatientsMedicines { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Setup composite PK
        modelBuilder.Entity<PatientMedicine>()
            .HasKey(pm => new { pm.PatientId, pm.MedicineId });
    }
}
