using System.ComponentModel;

namespace ContainerizedDB.Domain.Enums
{
    public enum DbTypeEnum
    {
        [Description("None")]
        None = 0,

        [Description("Sql")]
        Sql = 1,

        [Description("NoSql")]
        NoSql = 2,
    }
}
