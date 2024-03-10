using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class ApiDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeSubmit> ChallengeSubmits { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
