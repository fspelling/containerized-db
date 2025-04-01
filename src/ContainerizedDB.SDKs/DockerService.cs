using ContainerizedDB.Domain.Interfaces.ServiceSDKs;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace ContainerizedDB.ServiceSDKs
{
    public class DockerService(DockerClient dockerClient) : IDockerService
    {
        private readonly DockerClient _dockerClient = dockerClient;

        public async Task<int> CriarDatabaseNoSql(string rootUser, string rootPassword)
        {
            var portBindingCreate = new Random().Next(4000, 9999);

            //var responseContainer = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            //{
            //    Image = "postgres:16.8-alpine3.20",
            //    Name = $"postgres_{new Random().Next(999999)}_BD",
            //    Env = [$"POSTGRES_USER={user}", $"POSTGRES_PASSWORD={password}", $"POSTGRES_DB={db}"],
            //    HostConfig = new HostConfig
            //    {
            //        PortBindings = new Dictionary<string, IList<PortBinding>>
            //        {
            //            { "80/tcp", new List<PortBinding> { new PortBinding { HostPort = portBindingCreate.ToString() } }}
            //        }
            //    }
            //});

            await _dockerClient.Containers.StartContainerAsync("", new ContainerStartParameters());
            return portBindingCreate;
        }

        public async Task<int> CriarDatabaseSql(string user, string password, string db)
        {
            var portBindingCreate = new Random().Next(4000, 9999);
            var volumeContainer = "/var/lib/postgresql/data";

            var volumeDocker = await _dockerClient.Volumes.CreateAsync(new VolumesCreateParameters { Name = $"volume_postgre_{portBindingCreate}" });

            var responseContainer = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = "postgres:16.8-alpine3.20",
                Name = $"postgres_{new Random().Next(999999)}_BD",
                Env = new List<string>
                {
                    $"POSTGRES_USER={user}",
                    $"POSTGRES_PASSWORD={password}",
                    $"POSTGRES_DB={db}"
                },
                Volumes = new Dictionary<string, EmptyStruct>
                {
                    { volumeContainer, new EmptyStruct() }
                },
                HostConfig = new HostConfig
                {
                    Binds = new List<string> { $"{volumeDocker.Name}:{volumeContainer}" },
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "5432/tcp", new List<PortBinding> { new PortBinding { HostPort = portBindingCreate.ToString() } }}
                    }
                }
            });

            await _dockerClient.Containers.StartContainerAsync(responseContainer.ID, new ContainerStartParameters());
            return portBindingCreate;
        }
    }
}
