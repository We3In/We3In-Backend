using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;

        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();



        public IQueryable<T> GetAll(bool track = true)
        {
            var query = Table.AsQueryable();
            if (!track)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool track = true)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id), "id must exist.");
            var query = Table.AsQueryable();
            if(!track)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id)) ?? throw new ArgumentException(nameof(T));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool track = true)
        {
            var query = Table.AsQueryable();
            if (!track)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method) ?? throw new ArgumentException(nameof(T));
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool track = true)
        {
            var query = Table.Where(method);
            if (!track)
                query = query.AsNoTracking();
            return query;
        }
    }
}
