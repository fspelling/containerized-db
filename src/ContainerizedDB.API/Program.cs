using ContainerizedDB.API.Config;
using ContainerizedDB.API.Endpoints;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.ConfigureInjectDependency();

var app = builder.Build();

var fullApi = app.MapGroup("/todos");
fullApi.MapContainerEndpoints();

app.Run();