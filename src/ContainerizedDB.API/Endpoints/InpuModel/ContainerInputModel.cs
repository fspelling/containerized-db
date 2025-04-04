using ContainerizedDB.Domain.Enums;

namespace ContainerizedDB.API.Endpoints.Request
{
    public class ContainerInputModel
    {
        public DbTypeEnum DbType { get; set; }
        public required string UserDB { get; set; }
        public required string PasswordDB { get; set; }
        public string? DataBase { get; set; }
    }
}
