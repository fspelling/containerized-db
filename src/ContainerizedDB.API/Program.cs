using ContainerizedDB.API.Config;
using ContainerizedDB.API.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddOpenApi();
builder.Services.ConfigureInjectDependency();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapScalarApiReference();

var mapEndpointContainers = app.MapGroup("api/containersDB");
mapEndpointContainers.MapContainerEndpoints();

app.Run();