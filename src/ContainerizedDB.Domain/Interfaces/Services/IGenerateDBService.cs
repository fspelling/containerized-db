using ContainerizedDB.Domain.Enums;

namespace ContainerizedDB.Domain.Interfaces.Services
{
    public interface IGenerateDBService
    {
        Task<int> CreateDatabase(DbTypeEnum dbType, string user, string password, string? db);
    }
}
