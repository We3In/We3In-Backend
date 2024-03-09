using Application.Repositories.ChallengeRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.ChallengeRepository
{
    public class ChallengeWriteRepository : WriteRepository<Challenge>,  IChallengeWriteRepository
    {
        public ChallengeWriteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
