using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

using MyQuiver.IoC;
using MyQuiver.Repository;
using MyQuiver.Model.Repository;

namespace MyQuiver.Model
{
    public class IocRegistrations : IRegister
    {
        public void Register(ContainerBuilder container)
        {
            container.RegisterType<UserRepository>().As<IUserRepository>();
            container.RegisterType<LimbRepository>().As<ILimbRepository>();
        }
    }
}
