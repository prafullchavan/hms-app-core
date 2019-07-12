using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lexis.hms.data.Models
{
    public partial class lexis_hmsContext : DbContext
    {
        public virtual DbSet<LoginSession> LoginSession { get; set; }
        public virtual DbSet<MtnAddressType> MtnAddressType { get; set; }
        public virtual DbSet<MtnCaste> MtnCaste { get; set; }
        public virtual DbSet<MtnCity> MtnCity { get; set; }
        public virtual DbSet<MtnCountry> MtnCountry { get; set; }
        public virtual DbSet<MtnReligion> MtnReligion { get; set; }
        public virtual DbSet<MtnState> MtnState { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAddress> PatientAddress { get; set; }
        public virtual DbSet<PatientContact> PatientContact { get; set; }
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

            modelBuilder.Entity<MtnAddressType>(entity =>
            {
                entity.HasKey(e => e.AddressTypeId);

                entity.ToTable("mtn_AddressType");

                entity.Property(e => e.AddressTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnAddressTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_AddressType_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnAddressTypeUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_AddressType_UserProfile1");
            });

            modelBuilder.Entity<MtnCaste>(entity =>
            {
                entity.HasKey(e => e.ReligionId);

                entity.ToTable("mtn_caste");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReligionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnCasteCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_caste_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnCasteUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_caste_UserProfile1");
            });

            modelBuilder.Entity<MtnCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("mtn_City");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnCityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_city_UserProfile");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.MtnCity)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_City_mtn_State");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnCityUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_city_UserProfile1");
            });

            modelBuilder.Entity<MtnCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("mtn_Country");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnCountryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_Country_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnCountryUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_Country_UserProfile1");
            });

            modelBuilder.Entity<MtnReligion>(entity =>
            {
                entity.HasKey(e => e.ReligionId);

                entity.ToTable("mtn_Religion");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReligionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnReligionCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_Religion_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnReligionUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_Religion_UserProfile1");
            });

            modelBuilder.Entity<MtnState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("mtn_State");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MtnStateCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mtn_State_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MtnStateUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_mtn_State_UserProfile1");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Age)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FhfirstName)
                    .HasColumnName("FHFirstName")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FhlastName)
                    .HasColumnName("FHLastName")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_Patient_UserProfile1");
            });

            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AddressTypeNavigation)
                    .WithMany(p => p.PatientAddress)
                    .HasForeignKey(d => d.AddressType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAddress_PatientAddress");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.PatientAddress)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK_PatientAddress_mtn_City");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientAddressCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAddress_UserProfile");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAddress)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAddress_Patient");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientAddressUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_PatientAddress_UserProfile1");
            });

            modelBuilder.Entity<PatientContact>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientContactCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientContact_UserProfile");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PatientContactUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_PatientContact_UserProfile1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserKey);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_UserProfile");
            });
        }
    }
}
