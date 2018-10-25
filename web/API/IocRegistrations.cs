using System;
using System.Collections.Generic;
using System.Text;

using Autofac;
using MyQuiver.IoC;
using MyQuiver.Services;
using MyQuiver.Services.Implementation;

namespace MyQuiver.Web.Api
{
    public class IocRegistrations : IRegister
    {
        public void Register(ContainerBuilder container)
        {
            container.RegisterType<UserService>().As<IUserService>();
        }
    }
}
