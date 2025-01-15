using Dentistry.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext):base(dbContext) { }
       
        public DbSet<Dentist> Dentists { get; set; }   
        public DbSet<Patient> Patients { get; set; }   
        public DbSet<DentalOrder> DentalOrders { get; set; }
        public DbSet<OrderStatus> OrderStatus {  get; set; }   
    }
}
