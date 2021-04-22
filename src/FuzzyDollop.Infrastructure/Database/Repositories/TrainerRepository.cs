using System;
using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Domain.Entities;
using FuzzyDollop.Domain.Repositories;

namespace FuzzyDollop.Infrastructure.Database.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DexContext _dbContext;

        public TrainerRepository(DexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trainer> GetAsync(Guid trainerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Trainers.FindAsync(new object[] { trainerId }, cancellationToken);
        }
        
        public async Task AddAsync(Trainer trainer, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(trainer, cancellationToken);
        }
        
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
