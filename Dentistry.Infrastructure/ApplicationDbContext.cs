using Dentistry.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        public DbSet<Dentist> Dentists { get; set; }   
        public DbSet<Patient> Patients { get; set; }   
        public DbSet<DentalOrder> DentalOrders { get; set; }
        public DbSet<OrderStatus> OrderStatus {  get; set; }
        public DbSet<User> Users {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>()
              .Property(p => p.Id)
              .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}
