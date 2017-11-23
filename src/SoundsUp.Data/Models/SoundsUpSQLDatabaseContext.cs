using Microsoft.EntityFrameworkCore;

namespace SoundsUp.Data.Models
{
    public partial class SoundsUpSQLDatabaseContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }

        public SoundsUpSQLDatabaseContext(DbContextOptions<SoundsUpSQLDatabaseContext> options)
            : base(options)
        { }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=tcp:projectnorth.database.windows.net,1433;Initial Catalog=SoundsUpSQLDatabase;Persist Security Info=False;User ID=RootAdmin;Password=DatabaseIsAwesome1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("displayName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt");
            });
        }
    }
}