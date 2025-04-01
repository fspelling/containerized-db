using ContainerizedDB.API.Endpoints.Request;
using System.Text.Json.Serialization;

namespace ContainerizedDB.API.Config
{
    [JsonSerializable(typeof(ContainerCreateRequest))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {
    }
}
