using FuzzyDollop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuzzyDollop.Infrastructure.Database
{
    public class DexContext : DbContext
    {
        public DexContext(DbContextOptions<DexContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DexContext).Assembly);
        }
    }
}