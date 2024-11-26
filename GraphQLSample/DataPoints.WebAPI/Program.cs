using DataPoints.Mutations.Extensions;
using DataPoints.Persistence.Context;
using DataPoints.Queries.Extensions;
using DataPoints.Types.Extensions;
using DataPoints.WebAPI.Commond;
using DataPoints.WebAPI.Mapping;
using GraphQL.Server.Ui.Playground;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<AppDbContext>()
    .AddPersistenceServices()
    .AddGraphQLServer()
    .AddDataPointTypes()
    .AddQueryTypes()
    .AddMutationTypes();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("AllowAll");
app.UseRouting();

app.UseGraphQLPlayground("/ui/playground", new PlaygroundOptions
{
    GraphQLEndPoint = "/graphql"
});

app.UseWebSockets();
app.MapGraphQL();

app.Run();