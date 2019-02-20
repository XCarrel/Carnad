using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AddressBook.Models
{
    public partial class CarnadContext : DbContext
    {
        public CarnadContext()
        {
        }

        public CarnadContext(DbContextOptions<CarnadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Belong> Belong { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Carnad;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Belong>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactId).HasColumnName("Contact_id");

                entity.Property(e => e.GroupId).HasColumnName("Group_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Belong)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Belong_Contact");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Belong)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Belong_Group");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName })
                    .HasName("UniqueContact")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Country");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Countrie__737584F6536C97A7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Groups__737584F640D6FDD9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
