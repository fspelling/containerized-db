using ContainerizedDB.Domain.Interfaces.Services;
using ContainerizedDB.Domain.Interfaces.ServiceSDKs;
using ContainerizedDB.DomainService;
using ContainerizedDB.ServiceSDKs;
using Docker.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace ContainerizedDB.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDockerService, DockerService>();
            services.AddScoped<IGenerateDBService, GenerateDBService>();

            RegisterDockerConfig(services);
        }

        private static void RegisterDockerConfig(IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var config = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"));
                return config.CreateClient();
            });
        }
    }
}
