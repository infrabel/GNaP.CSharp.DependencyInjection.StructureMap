namespace GNaP.DependencyInjection.StructureMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DependencyInjection;
    using global::StructureMap;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// This adapter provides an implementation of the IContainerAdapter interface.
    /// It relies fully on structuremap.
    /// </summary>
    public class StructureMapAdapter : ContainerAdapter
    {
        private readonly IContainer _container;

        internal IContainer Container { get { return _container; } }

        internal StructureMapAdapter(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        /// the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>The requested service instance.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                    return _container.GetInstance(serviceType, key);

                if (serviceType.IsAbstract || serviceType.IsInterface)
                    return _container.TryGetInstance(serviceType);

                return _container.GetInstance(serviceType);
            }
            catch (Exception e)
            {
                throw new ActivationException("Error during structuremap instance resolving", e);
            }
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        /// resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            try
            {
                return _container.GetAllInstances(serviceType).Cast<object>();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public override void Add(Type serviceType, Type implementationType)
        {
            _container.Configure(x => x.For(serviceType).Use(implementationType));
        }

        public override void AddSingleton(Type serviceType, Type implementationType)
        {
            _container.Configure(x => x.For(serviceType).Use(implementationType).Singleton());
        }

        public override void AddInstance(Type serviceType, object implementation)
        {
            _container.Configure(x => x.For(serviceType).Use(implementation));
        }
    }
}
