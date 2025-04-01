using ContainerizedDB.IoC;

namespace ContainerizedDB.API.Config
{
    public static class IocConfig
    {
        public static void ConfigureInjectDependency(this IServiceCollection services)
            => NativeInjectorBootStrapper.RegisterServices(services);
    }
}
