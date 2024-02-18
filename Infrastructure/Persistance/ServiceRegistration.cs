using Application.Repositories.EventRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.EventRepositories;
using Persistance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceRegistration
    {

        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(
                opt => opt.UseNpgsql(GetConnectionString.GetConnection()));
            
            services.AddScoped<DbContext, ApiDbContext>();

            services.AddScoped<IEventReadRepository, EventReadRepository>();

        }
    }
}
