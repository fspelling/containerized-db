using ContainerizedDB.Domain.Entidades;
using ContainerizedDB.Domain.Enums;

namespace ContainerizedDB.Domain.Interfaces.ServiceSDKs
{
    public interface IDockerService
    {
        Task<ContainerDB> CriarContainer(DbTypeEnum dbType, List<string> envs);
        Task<List<ContainerDB>> ListarContainers();
        Task IniciarContainer(string idContainer);
        Task PausarContainer(string idContainer);
        Task RemoverContainer(string idContainer);
    }
}
