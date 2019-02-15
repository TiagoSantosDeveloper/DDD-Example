using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SonicParks.Core.Application.Interfaces.ViewsModels;
using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SonicParks.Core.CrossCutting.AutoMap.EntityMapping;
using SonicParks.Core.Application.ViewsModels;

namespace SonicParks.Core.CrossCutting.IoC.AutoMapping {

    public static class CustomAutoMapping {

        public static void Register(IServiceCollection services, IConfiguration configuration) {

            AutoMap.EntityMapping.AutoMapping.Register<IUserRegisterViewModel, UserEntity>();
            //AutoMap.EntityMapping.AutoMapping.Register<IUserLoginViewModel, UserEntity>();

        }

    }

}
