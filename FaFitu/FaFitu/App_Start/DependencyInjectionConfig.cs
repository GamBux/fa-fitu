using FaFitu.DatabaseUtils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace FaFitu.App_Start
{
    public class DependencyInjectionConfig : IConfigureUnity
    {
        public void Configure(UnityContainer container)
        {
            container
                .RegisterType<IFoodRepository, FoodRepository>()
                .RegisterType<IUsersRepository, UsersRepository>()
                ;

        }
    }
}