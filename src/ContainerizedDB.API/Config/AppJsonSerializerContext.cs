using ContainerizedDB.API.Endpoints.Request;
using ContainerizedDB.API.Endpoints.Response;
using ContainerizedDB.API.Endpoints.ViewModel.Base;
using System.Text.Json.Serialization;

namespace ContainerizedDB.API.Config
{
    [JsonSerializable(typeof(ContainerInputModel))]
    [JsonSerializable(typeof(CustomResponseViewModel))]
    [JsonSerializable(typeof(CustomResponseViewModel<ContainerViewModel>))]
    [JsonSerializable(typeof(CustomResponseViewModel<List<ContainerViewModel>>))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {
    }
}
