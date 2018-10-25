using System;
using Autofac;

namespace MyQuiver.IoC
{
    public interface IRegister
    {
        /// <summary>
        /// Set up inversion of control registrations
        /// </summary>
        /// <param name="container">Container.</param>
        void Register(ContainerBuilder container);
    }
}
