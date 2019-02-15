using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SonicParks.Core.Application.AppServices;
using SonicParks.Core.Application.Interfaces.AppServices;
using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Domain.Interfaces.Persistence;
using SonicParks.Core.Domain.Interfaces.Repositories;
using SonicParks.Core.Domain.Interfaces.Services;
using SonicParks.Core.Domain.Services;
using SonicParks.Core.Infrastructure.Data.Contexts;
using SonicParks.Core.Infrastructure.Data.Persistence;
using SonicParks.Core.Infrastructure.Data.Repositories.Users;
using System;
using System.Configuration;

namespace SonicParks.Core.CrossCutting.IoC.DependencyInjection {

    public static class CustomService {

        public static void Register(IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<BaseContext, SonicParksNexContext>(s => s.UseSqlServer(configuration.GetConnectionString("SonicParksNex")));

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork<UserEntity>, UnitOfWork<UserEntity>>();
            services.AddScoped<IUserAppService, UserAppService>();

        }

    }

}
