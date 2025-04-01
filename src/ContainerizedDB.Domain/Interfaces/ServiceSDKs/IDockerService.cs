namespace ContainerizedDB.Domain.Interfaces.ServiceSDKs
{
    public interface IDockerService
    {
        Task<int> CriarDatabaseSql(string user, string password, string db);
        Task<int> CriarDatabaseNoSql(string rootUser, string rootPassword);
    }
}
