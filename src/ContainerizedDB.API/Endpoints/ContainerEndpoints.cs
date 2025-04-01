using ContainerizedDB.API.Endpoints.Request;
using ContainerizedDB.Domain.Enums;
using ContainerizedDB.Domain.Interfaces.Services;

namespace ContainerizedDB.API.Endpoints
{
    public static class ContainerEndpoints
    {
        public static void MapContainerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/containers", async (ContainerCreateRequest request, IGenerateDBService generateDBService) =>
            {
                var response = await generateDBService.CreateDatabase(DbTypeEnum.None, "", "");
                Results.Ok(response);
            });
        }
    }
}
