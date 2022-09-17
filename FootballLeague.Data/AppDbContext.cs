using FootballLeague.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FootballLeague.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foreignKeys = modelBuilder.Model
                                .GetEntityTypes()
                                .SelectMany(e => e.GetForeignKeys()
                                    .Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
