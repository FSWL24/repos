using DataPoints.Mutations.Extensions;
using DataPoints.Mutations.MutationTypes;
using DataPoints.Persistence.Context;
using DataPoints.Queries.Extensions;
using DataPoints.Types.Extensions;
using DataPoints.WebAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services
    .AddDbContext<AppDbContext>()
    .AddPersistenceServices()
    .AddGraphQLServer()
    .AddDataPointTypes()
    .AddQueryTypes()
    .AddMutationTypes()
    .AddSubscriptionTypes()
    .AddInMemorySubscriptions();
    

builder.Services.AddSingleton<IDataPointsDictionaryService, DataPointsDictionaryService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://studio.apollographql.com", "http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2) 
});
app.MapGraphQL();

app.Run();