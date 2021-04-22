using System;
using FuzzyDollop.Domain.Entities;

namespace FuzzyDollop.Domain.Factories
{
    public class TrainerFactory : ITrainerFactory
    {
        public Trainer Create(Guid id, string firstName, string lastName)
        {
            return new Trainer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}