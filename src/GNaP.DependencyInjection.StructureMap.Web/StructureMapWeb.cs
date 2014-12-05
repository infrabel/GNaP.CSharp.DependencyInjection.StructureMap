namespace GNaP.DependencyInjection.StructureMap.Web
{
    using System;
    using global::StructureMap;
    using DependencyInjection.Web;

    public static class StructureMapWeb
    {
        private static IContainer EmptyContainer
        {
            get { return new Container(); }
        }

        public static IWebContainerAdapter Create()
        {
            return new StructureMapWebAdapter(EmptyContainer);
        }

        public static IWebContainerAdapter Create(Action<StructureMapWebAdapter> configureContainerFunc)
        {
            if (configureContainerFunc == null)
                throw new ArgumentNullException("configureContainerFunc");

            var container = new StructureMapWebAdapter(EmptyContainer);
            configureContainerFunc(container);
            return container;
        }

        public static IWebContainerAdapter Create(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            return new StructureMapWebAdapter(container);
        } 
    }
}
