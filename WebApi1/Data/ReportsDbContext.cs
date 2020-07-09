using Microsoft.EntityFrameworkCore;
using WebApi1.Data;

namespace WebApi1
{
    public class ReportsDbContext :DbContext
    {

        public ReportsDbContext()
        {

        }

        public ReportsDbContext(DbContextOptions<ReportsDbContext> options):base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReportsDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        //}

        public DbSet<ReportSettings> ReportSettings { get; set; }
        
        public DbSet<ReportData> ReportData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportSettings>(entity =>
            {   entity.Property(p => p.Id).HasMaxLength(128);
                entity.HasKey(p => p.Id);
            }
            );

            modelBuilder.Entity<ReportData>(entity =>
            {
                entity.Property(p => p.Id).HasMaxLength(128);
                entity.Property(p => p.ReportSettingsId).HasMaxLength(128);
                entity.Property(p => p.FileType).HasMaxLength(64);
                entity.HasKey(p => p.Id);
            }
            );                                    

            modelBuilder.Entity<ReportData>()
                .HasOne(p => p.ReportSettings)
                .WithMany(b => b.Reports)
                .HasForeignKey(p => p.ReportSettingsId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}