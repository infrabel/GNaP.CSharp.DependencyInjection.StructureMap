namespace GNaP.DependencyInjection.StructureMap
{
    using System;
    using global::StructureMap;

    public static class StructureMap
    {
        private static IContainer EmptyContainer
        {
            get { return new Container(); }
        }

        public static IContainerAdapter Create()
        {
            return new StructureMapAdapter(EmptyContainer);
        }

        public static IContainerAdapter Create(Action<StructureMapAdapter> configureContainerFunc)
        {
            if (configureContainerFunc == null)
                throw new ArgumentNullException("configureContainerFunc");

            var container = new StructureMapAdapter(EmptyContainer);
            configureContainerFunc(container);
            return container;
        }

        public static IContainerAdapter Create(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            return new StructureMapAdapter(container);
        } 
    }
}
