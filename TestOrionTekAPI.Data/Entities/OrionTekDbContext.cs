using Microsoft.EntityFrameworkCore;

namespace TestOrionTekAPI.Data.Entities
{
    public class OrionTekDbContext : DbContext
    {
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        public OrionTekDbContext()
        {
            
        }

        public OrionTekDbContext(DbContextOptions<OrionTekDbContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employees>(conf => {
                conf.HasKey(k => k.Id);
                conf.Property(a=>a.Id).HasDefaultValueSql("(newid())");
                conf.HasMany(ho => ho.Address)
                    .WithOne(wm => wm.Employees)
                    .HasForeignKey(fk => fk.EmployeesId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Address>(conf => {
                conf.HasKey(k => k.Id);
                conf.Property(a => a.Id).HasDefaultValueSql("(newid())");
                conf.HasOne(ho => ho.Employees)
                    .WithMany(wm => wm.Address)
                    .HasForeignKey(fk => fk.EmployeesId);
            });
        }


    }
}
