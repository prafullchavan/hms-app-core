using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lexis.hms.services.Models
{
    public partial class lexis_hmsContext : DbContext
    {
        public virtual DbSet<LoginSession> LoginSession { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        public lexis_hmsContext(DbContextOptions<lexis_hmsContext> options)
: base(options)
        { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Integrated Security=SSPI;Database=lexis_hms;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginSession>(entity =>
            {
                entity.Property(e => e.LoginSessionId).ValueGeneratedOnAdd();

                entity.Property(e => e.AuthToken).IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogOutTime).HasColumnType("datetime");

                entity.Property(e => e.LoginErrorCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LoginSessionNavigation)
                    .WithOne(p => p.LoginSession)
                    .HasForeignKey<LoginSession>(d => d.LoginSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginSession_UserProfile");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserKey);

                entity.Property(e => e.UserKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithOne(p => p.InverseUserKeyNavigation)
                    .HasForeignKey<UserProfile>(d => d.UserKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_UserProfile");
            });
        }
    }
}
