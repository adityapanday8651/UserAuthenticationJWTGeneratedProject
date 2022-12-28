using Microsoft.EntityFrameworkCore;
using UserAuthenticationJWTGenerated.Dtos;
using UserAuthenticationJWTGenerated.Models;

namespace UserAuthenticationJWTGenerated.Data
{
    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<RegisterDto> RegisterDtos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
