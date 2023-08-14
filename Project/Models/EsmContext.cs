using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class EsmContext : DbContext
{
    public EsmContext()
    {
    }

    public EsmContext(DbContextOptions<EsmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<LevelOfLanguage> LevelOfLanguages { get; set; }

    public virtual DbSet<LineOfAccount> LineOfAccounts { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8LIUS4D\\SQLEXPRESS01;Database=ESM;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity
               // .HasNoKey()
                .ToTable("Account", "EM");

            entity.Property(e => e.Account1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Languagelevel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("languagelevel");
            entity.Property(e => e.Lineofbusiness)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nationalid)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LevelOfLanguage>(entity =>
        {
            entity
               // .HasNoKey()
                .ToTable("LevelOfLanguage", "EM");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Languagelevel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("languagelevel");
        });

        modelBuilder.Entity<LineOfAccount>(entity =>
        {
            entity
               // .HasNoKey()
                .ToTable("LineOfAccount", "EM");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lineofbusiness)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Lineofbusiness");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("Login", "EM");

            entity.Property(e => e.Emil)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Security)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("security");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
