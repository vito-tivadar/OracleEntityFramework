using Microsoft.EntityFrameworkCore;

namespace OracleEntityFramework.DbContex
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


            entity.HasMany(u => u.Role)
              .WithMany()
              .UsingEntity<Dictionary<string, object>>(
                  "UserRole", // join table
                  j => j.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Role"),
                  j => j.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_User"),
                  j =>
                  {
                      j.ToTable("UserRoles"); // join table name
                      j.HasKey("UserId", "RoleId");
                  });
        }
    }
}
