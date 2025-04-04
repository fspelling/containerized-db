using ContainerizedDB.Domain.Entidades;
using ContainerizedDB.Domain.Enums;

namespace ContainerizedDB.Domain.Interfaces.Services
{
    public interface IGenerateDBService
    {
        Task<ContainerDB> CreateDatabase(DbTypeEnum dbType, string user, string password, string? db);
        Task<List<ContainerDB>> ListarContainerDataBase();
        Task IniciarContainerDataBase(string idContainer);
        Task PausarContainerDataBase(string idContainer);
        Task RemoverContainerDataBase(string idContainer);
    }
}
