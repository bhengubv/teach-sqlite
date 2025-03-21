﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System.Diagnostics;
using CreateNewDatabaseApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CreateNewDatabaseApp.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExampleDapper2.db")};Pooling=False;")
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {

            entity.HasIndex(e => e.FirstName, "first_name_person1_idx");

            entity.HasIndex(e => e.LastName, "last_name_person1_idx");

            entity.HasIndex(e => e.Pin, "pin_person1_idx");

            entity.Property(e => e.BirthDate)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime");

            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();

            // single property case-insensitive
            //entity.Property(x => x.FirstName).HasColumnType("TEXT COLLATE NOCASE");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    /// <summary>
    /// https://stackoverflow.com/a/77283802/5509738
    /// Handle case-insensitive searches for SQLite
    /// </summary>
    /// <remarks>
    /// Single property
    /// entity.Property(x => x.FirstName).HasColumnType("TEXT COLLATE NOCASE");
    /// as per commented out code in OnModelCreating
    /// </remarks>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().UseCollation("NOCASE");
    }
}

