using FaFitu.DatabaseUtils;
using FaFitu.Tests.MockedDatabaseUtils;
using Infrastructure;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Tests
{
    public class DependencyInjectionConfig : IConfigureUnity
    {
        public void Configure(UnityContainer container)
        {
            container
                .RegisterType<IFoodRepository, MockedFoodRepository>()
                .RegisterType<IUsersRepository, MockedUsersRepository>()
                ;

        }
    }
}
