using Microsoft.EntityFrameworkCore;
using Proekt.Models;

namespace Proekt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        {
            
        }   
        public DbSet <Guest> Guest { get; set; }
        public DbSet <Room> Room { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Room entity
            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(r => r.Type).IsRequired();
            });

            // Configure Guest entity
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(g => g.FirstName).HasMaxLength(200).IsRequired();
                entity.Property(g => g.LastName).HasMaxLength(400).IsRequired();
                entity.Property(g => g.Address).HasMaxLength(600).IsRequired();
                entity.Property(g => g.DOB).IsRequired();
                entity.Property(g => g.Nationality).IsRequired();
                entity.Property(g => g.CheckInDate).IsRequired();
                entity.Property(g => g.CheckOutDate).IsRequired();

                entity.HasOne(g => g.Room)
                      .WithMany(r => r.Guests)
                      .HasForeignKey(g => g.RoomId);
            });
        }
    }

}
