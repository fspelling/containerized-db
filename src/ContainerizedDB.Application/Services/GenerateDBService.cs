using ContainerizedDB.Domain.Entidades;
using ContainerizedDB.Domain.Enums;
using ContainerizedDB.Domain.Interfaces.Services;
using ContainerizedDB.Domain.Interfaces.ServiceSDKs;

namespace ContainerizedDB.Application.Services
{
    public class GenerateDBService(IDockerService dockerService) : IGenerateDBService
    {
        private readonly IDockerService _dockerService = dockerService;

        public async Task<ContainerDB> CreateDatabase(DbTypeEnum dbType, string user, string password, string? db)
        {
            ValidarCriacaoDB(dbType, user, password, db);

            return await _dockerService.CriarContainer(dbType,
                                                        dbType == DbTypeEnum.Sql ?
                                                        new List<string>()
                                                        {
                                                            $"POSTGRES_USER={user}",
                                                            $"POSTGRES_PASSWORD={password}",
                                                            $"POSTGRES_DB={db}"
                                                        } :
                                                        new List<string>()
                                                        {
                                                            $"MONGO_INITDB_ROOT_USERNAME={user}",
                                                            $"MONGO_INITDB_ROOT_PASSWORD={password}"
                                                        });
        }

        public async Task IniciarContainerDataBase(string idContainer)
        {
            if(idContainer is null)
                throw new ArgumentNullException("Container deve ser informado!");

            await _dockerService.IniciarContainer(idContainer);
        }

        public async Task<List<ContainerDB>> ListarContainerDataBase()
            => await _dockerService.ListarContainers();

        public async Task PausarContainerDataBase(string idContainer)
        {
            if (idContainer is null)
                throw new ArgumentNullException("Container deve ser informado!");

            await _dockerService.PausarContainer(idContainer);
        }

        public async Task RemoverContainerDataBase(string idContainer)
        {
            if (idContainer is null)
                throw new ArgumentNullException("Container deve ser informado!");

            await _dockerService.RemoverContainer(idContainer);
        }

        private void ValidarCriacaoDB(DbTypeEnum dbType, string user, string password, string? db)
        {
            if (user is null || password is null)
                throw new ArgumentNullException("Credenciais nao informado!");

            if (dbType == DbTypeEnum.None)
                throw new ArgumentNullException("Deve ser informado o tipo do BD");

            if (dbType == DbTypeEnum.Sql && string.IsNullOrEmpty(db))
                throw new ArgumentNullException("banco de dados deve ser informado!");
        }
    }
}
