using HeribertoAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HeribertoAPI.Data
{
    public class HeribertoDbContext : DbContext
    {
        public HeribertoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

    }
}
