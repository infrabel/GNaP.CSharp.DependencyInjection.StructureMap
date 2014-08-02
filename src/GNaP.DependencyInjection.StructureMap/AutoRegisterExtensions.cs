namespace GNaP.DependencyInjection.StructureMap
{
    using global::StructureMap.Graph;

    public static class AutoRegisterExtensions
    {
        public static void AutoRegister(this StructureMapAdapter containerAdapter)
        {
            containerAdapter.Container
                            .Configure(x => x.Scan(y =>
            {
                y.WithDefaultConventions();
                y.AssembliesFromApplicationBaseDirectory();
                y.RegisterConcreteTypesAgainstTheFirstInterface();
            }));
        }
    }
}