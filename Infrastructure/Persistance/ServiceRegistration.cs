using Application.Abstraction.Services;
using Application.Repositories.ChallengeRepository;
using Application.Repositories.EventRepository;
using Domain.Entities.Identity;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.ChallengeRepository;
using Persistance.Repositories.EventRepositories;
using Persistance.Utils;

namespace Persistance
{
    public static class ServiceRegistration
    {

        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(
                opt => opt.UseNpgsql(GetConnectionString.GetConnection()));
            
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApiDbContext>();

            services.AddScoped<DbContext, ApiDbContext>();

            services.AddScoped<IEventReadRepository, EventReadRepository>();
            services.AddScoped<IEventWriteRepository, EventWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IChallengeReadRepository, ChallengeReadRepository>();
            services.AddScoped<IChallengeWriteRepository, ChallengeWriteRepository>();


        }
    }
}
