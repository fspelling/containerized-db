using ContainerizedDB.API.Endpoints.Request;
using ContainerizedDB.API.Endpoints.Response;
using ContainerizedDB.API.Endpoints.ViewModel.Base;
using ContainerizedDB.Domain.Interfaces.Services;

namespace ContainerizedDB.API.Endpoints
{
    public static class ContainerDbEndpoints
    {
        public static void MapContainerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/create", async (ContainerInputModel request, IGenerateDBService generateDBService) =>
            {
                var response = await generateDBService.CreateDatabase(request.DbType, request.UserDB, request.PasswordDB, request.DataBase);

                return Results.Ok(new CustomResponseViewModel<ContainerViewModel>(new ContainerViewModel()
                {
                    ContainerId = response.Id, 
                    PortBinding = response.PortBinding,
                    ContainerImage = response.Image
                }));
            });

            app.MapPost("{idContainer}/start", async (string idContainer, IGenerateDBService generateDBService) =>
            {
                await generateDBService.IniciarContainerDataBase(idContainer);
                return Results.Ok(new CustomResponseViewModel());
            });

            app.MapGet("/", async (IGenerateDBService generateDBService) =>
            {
                var response = await generateDBService.ListarContainerDataBase();
                var respList = response.Select(resp => new ContainerViewModel
                {
                    ContainerId = resp.Id,
                    PortBinding = resp.PortBinding,
                    ContainerImage = resp.Image
                }).ToList();

                return Results.Ok(new CustomResponseViewModel<List<ContainerViewModel>>(respList));
            });

            app.MapPost("/{idContainer}/stop", async (string idContainer, IGenerateDBService generateDBService) =>
            {
                await generateDBService.PausarContainerDataBase(idContainer);
                return Results.Ok(new CustomResponseViewModel());
            });

            app.MapDelete("/{idContainer}", async (string idContainer, IGenerateDBService generateDBService) =>
            {
                await generateDBService.RemoverContainerDataBase(idContainer);
                return Results.Ok(new CustomResponseViewModel());
            });
        }
    }
}
