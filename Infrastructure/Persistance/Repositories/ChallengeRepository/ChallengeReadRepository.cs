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
    public class ChallengeReadRepository : ReadRepository<Challenge>, IChallengeReadRepository
    {
        public ChallengeReadRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
