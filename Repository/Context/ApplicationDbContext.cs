namespace Repository.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Reflection.PortableExecutable;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    //using IRepository.Entity;
    using PRN222_Group_Project.Models.Entities;

    public class ApplicationDbContext : DbContext
    {
        // Constructor with options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VaccineCenter> VaccineCenters { get; set; }
        public DbSet<VaccineBatch> VaccineBatches { get; set; }
        public DbSet<VaccineCategory> VaccineCategories { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccinePackage> VaccinePackages { get; set; }
        public DbSet<VaccinePackageDetail> VaccinePackageDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChildrenProfile> ChildrenProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderVaccineDetail> OrderVaccineDetails { get; set; }
        public DbSet<OrderPackageDetail> OrderPackageDetails { get; set; }
        public DbSet<VaccineHistory> VaccineHistories { get; set; }
        public DbSet<VaccinationSchedule> VaccinationSchedules { get; set; }
        public DbSet<VaccineReaction> VaccineReactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=VaccineScheduleSystem;User Id=sa;Password=12345;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccineCategory>()
                .HasOne(v => v.ParentCategory)
                .WithMany()
                .HasForeignKey(v => v.FKParentCategoryId);

            modelBuilder.Entity<VaccineBatch>()
                .HasOne(vb => vb.Manufacturer)
                .WithMany()
                .HasForeignKey(vb => vb.FKManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccineBatch>()
                .HasOne(vb => vb.Center)
                .WithMany()
                .HasForeignKey(vb => vb.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.Category)
                .WithMany()
                .HasForeignKey(v => v.FKCategoryId);

            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.Batch)
                .WithMany()
                .HasForeignKey(v => v.FKBatchId);

            modelBuilder.Entity<VaccinePackageDetail>()
                .HasOne(vpd => vpd.Vaccine)
                .WithMany()
                .HasForeignKey(vpd => vpd.FKVaccineId);

            modelBuilder.Entity<VaccinePackageDetail>()
                .HasOne(vpd => vpd.VaccinePackage)
                .WithMany()
                .HasForeignKey(vpd => vpd.FKVaccinePackageId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Center)
                .WithMany()
                .HasForeignKey(a => a.FKCenterId);

            modelBuilder.Entity<ChildrenProfile>()
                .HasOne(cp => cp.Account)
                .WithMany()
                .HasForeignKey(cp => cp.FKAccountId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Feedback)
                .WithMany()
                .HasForeignKey(o => o.FKFeedbackId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Profile)
                .WithMany()
                .HasForeignKey(o => o.FKProfileId);



            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.FKOrderId);

            modelBuilder.Entity<OrderVaccineDetail>()
                .HasOne(ovd => ovd.Order)
                .WithMany()
                .HasForeignKey(ovd => ovd.FKOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderVaccineDetail>()
                .HasOne(ovd => ovd.Vaccine)
                .WithMany()
                .HasForeignKey(ovd => ovd.FKVaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderVaccineDetail>()
                .HasOne(ovd => ovd.Order)
                .WithMany()
                .HasForeignKey(ovd => ovd.FKOrderId);


            modelBuilder.Entity<OrderVaccineDetail>()
                .HasOne(ovd => ovd.Vaccine)
                .WithMany()
                .HasForeignKey(ovd => ovd.FKVaccineId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Vaccine)
                .WithMany()
                .HasForeignKey(vh => vh.FKVaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Profile)
                .WithMany()
                .HasForeignKey(vh => vh.FKProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Account)
                .WithMany()
                .HasForeignKey(vh => vh.FKAccountId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Center)
                .WithMany()
                .HasForeignKey(vh => vh.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.Profile)
                .WithMany()
                .HasForeignKey(vs => vs.FKProfileId);

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.Center)
                .WithMany()
                .HasForeignKey(vs => vs.FKCenterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.OrderVaccineDetail)
                .WithMany()
                .HasForeignKey(vs => vs.FKOrderVaccineDetailsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccinationSchedule>()
                .HasOne(vs => vs.OrderPackageDetail)
                .WithMany()
                .HasForeignKey(vs => vs.FKOrderPackageDetailsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VaccineReaction>()
                .HasOne(vr => vr.VaccineSchedule)
                .WithMany()
                .HasForeignKey(vr => vr.FKVaccineScheduleId);

        }
        // Define your DbSets here
        // public DbSet<YourModel> YourTable { get; set; }
    }
}
