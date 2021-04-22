using System;
using FuzzyDollop.Domain.Entities;

namespace FuzzyDollop.Domain.Factories
{
    public interface ITrainerFactory
    {
        Trainer Create(Guid id, string firstName, string lastName);
    }
}