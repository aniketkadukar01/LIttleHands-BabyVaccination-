using LittleHands.Data.Config;
using LittleHands.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleHands.Data
{
    public class LittleHandsContext : DbContext
    {
        public LittleHandsContext(DbContextOptions<LittleHandsContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
