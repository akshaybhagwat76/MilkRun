using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MilkRun.UtilizeApp.Models
{
    public class MilkRunDbContext : DbContext
    {
        public MilkRunDbContext(DbContextOptions<MilkRunDbContext> options) : base(options) { }
        
        public virtual DbSet<AppDataUser> Data_User { get; set; }
        public virtual DbSet<AppPackagingPart> Tbl_Packaging_Part { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPackagingPart>()
      .HasKey(d => new { d.Part_No, d.Supplier_Code, d.Packaging_Type});
        }
    }
}
