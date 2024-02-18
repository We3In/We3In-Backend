using Application.Repositories;
using Application.Repositories.EventRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.EventRepositories
{
    public class EventWriteRepository : WriteRepository<Event>, IEventWriteRepository
    {
        public EventWriteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
