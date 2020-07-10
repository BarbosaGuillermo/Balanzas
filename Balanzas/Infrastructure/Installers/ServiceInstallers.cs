namespace Balanzas.Infrastructure.Installers
{
    using Models;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Balanzas.Models.Drivers;

    public class ServiceInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            container.Register(Component.For<BalanzasEntities>().LifeStyle.Transient);
            container.Register(Classes.FromThisAssembly().BasedOn<IDriver>().WithService.AllInterfaces().LifestyleTransient());
            container.Register(Component.For<DriverFactory>().LifeStyle.Transient);
            container.Register(Component.For<DeviceQuery>().LifeStyle.Transient);
        }
    }
}