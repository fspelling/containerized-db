using ContainerizedDB.Domain.Enums;
using ContainerizedDB.Domain.Interfaces.Services;
using ContainerizedDB.Domain.Interfaces.ServiceSDKs;

namespace ContainerizedDB.DomainService
{
    public class GenerateDBService(IDockerService dockerService) : IGenerateDBService
    {
        private readonly IDockerService _dockerService = dockerService;

        public async Task<int> CreateDatabase(DbTypeEnum dbType, string user, string password, string? db)
        {
            if (user is null || password is null)
                throw new ArgumentNullException("Credenciais nao informado!");

            if (dbType == DbTypeEnum.None)
                throw new ArgumentNullException("Deve ser informado o tipo do BD");

            if (dbType == DbTypeEnum.NoSql)
                return await _dockerService.CriarDatabaseNoSql(user, password);

            return await _dockerService.CriarDatabaseSql(user, password, db!);
        }
    }
}
