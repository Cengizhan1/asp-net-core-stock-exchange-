using Entity.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Share> Shares { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
