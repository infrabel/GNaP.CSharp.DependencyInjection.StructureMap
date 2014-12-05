namespace GNaP.DependencyInjection.StructureMap.Web
{
    using System;
    using DependencyInjection.StructureMap;
    using DependencyInjection.Web;
    using global::StructureMap;
    using global::StructureMap.Web;

    public class StructureMapWebAdapter : StructureMapAdapter, IWebContainerAdapter
    {
        private readonly IContainer _container;

        internal StructureMapWebAdapter(IContainer container) : base(container)
        {
            _container = container;
        }

        public void AddScoped(Type serviceType, Type implementationType)
        {
            _container.Configure(x => x.For(serviceType)
                      .HttpContextScoped()
                      .Use(implementationType));
        }
    }
}
