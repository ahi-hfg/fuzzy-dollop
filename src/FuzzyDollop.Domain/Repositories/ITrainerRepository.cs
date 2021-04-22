using System;
using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Domain.Entities;

namespace FuzzyDollop.Domain.Repositories
{
    public interface ITrainerRepository
    {
        Task<Trainer> GetAsync(Guid trainerId, CancellationToken cancellationToken);
        Task AddAsync(Trainer trainer, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
