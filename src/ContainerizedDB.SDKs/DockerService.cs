using ContainerizedDB.Domain.Entidades;
using ContainerizedDB.Domain.Enums;
using ContainerizedDB.Domain.Interfaces.ServiceSDKs;
using Docker.DotNet;
using Docker.DotNet.Models;
using System.Data;

namespace ContainerizedDB.ServiceSDKs
{
    public class DockerService(DockerClient dockerClient) : IDockerService
    {
        private readonly DockerClient _dockerClient = dockerClient;

        #region CONFIG CONST

        private const string IMAGE_SQL= "postgres:16.8-alpine3.20";
        private const string IMAGE_NOSQL = "mongodb:latest";
        private const string VOLUME_SQL = "/var/lib/postgresql/data";
        private const string VOLUME_NOSQL = "/data/db";
        private const int PORT_BINDING_SQL = 5432;
        private const int PORT_BINDING_NOSQL = 27017;

        #endregion

        public async Task<ContainerDB> CriarContainer(DbTypeEnum dbType, List<string> envs)
        {
            var portBindingCreate = new Random().Next(4000, 9999);
            var containerName = CriarNomeContainerBD(DbTypeEnum.Sql);
            var volumeDocker = await CreateVolumeContainerBD(dbType);
            var imageDatabase = dbType == DbTypeEnum.Sql ? IMAGE_SQL : IMAGE_NOSQL;
            var volumeDatabase = dbType == DbTypeEnum.Sql ? VOLUME_SQL : VOLUME_NOSQL;
            var portBindingContainer = dbType == DbTypeEnum.Sql ? PORT_BINDING_SQL : PORT_BINDING_NOSQL;

            var responseContainer = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = imageDatabase,
                Name = containerName,
                Env = envs,
                Volumes = new Dictionary<string, EmptyStruct>
                {
                    { volumeDatabase, new EmptyStruct() }
                },
                HostConfig = new HostConfig
                {
                    Binds = new List<string> { $"{volumeDocker.Name}:{volumeDatabase}" },
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { $"{portBindingContainer}/tcp", new List<PortBinding> { new PortBinding { HostPort = portBindingCreate.ToString() } }}
                    }
                }
            });

            await IniciarContainer(responseContainer.ID);
            return new ContainerDB { Id = responseContainer.ID, Image = imageDatabase, Name = containerName, PortBinding = portBindingCreate };
        }

        public async Task IniciarContainer(string idContainer)
            => await _dockerClient.Containers.StartContainerAsync(idContainer, new ContainerStartParameters());

        public async Task<List<ContainerDB>> ListarContainers()
        {
            var contaienrs = await _dockerClient.Containers.ListContainersAsync(new ContainersListParameters()
            {
                Filters = new Dictionary<string, IDictionary<string, bool>>()
                {
                    { "name", new Dictionary<string, bool> { { "_BD", true } } }
                }
            });

            var result = contaienrs.ToList().Select(c => new ContainerDB
            { 
                Id = c.ID, 
                Image = c.Image, 
                Name = c.Names[0], 
                PortBinding = c.Ports[0].PublicPort
            }).ToList();

            return result;
        }

        public async Task RemoverContainer(string idContainer)
            => await _dockerClient.Containers.RemoveContainerAsync(idContainer, new ContainerRemoveParameters { Force = true });

        public async Task PausarContainer(string idContainer)
            => await _dockerClient.Containers.StopContainerAsync(idContainer, new ContainerStopParameters());

        #region METODOS_AUXILIARES

        private async Task<VolumeResponse> CreateVolumeContainerBD(DbTypeEnum dbType)
            => await _dockerClient.Volumes.CreateAsync(new VolumesCreateParameters
            {
                Name = $"vol_{(dbType == DbTypeEnum.Sql ? "postgres" : "mongodb")}"
            });

        private string CriarNomeContainerBD(DbTypeEnum dbType)
            => $"{(dbType == DbTypeEnum.Sql ? "postgres" : "mongodb")}_{new Random().Next(999999)}_BD";

        #endregion
    }
}
