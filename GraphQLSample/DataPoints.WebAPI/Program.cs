using DataPoints.Mutations.Extensions;
using DataPoints.Persistence.Context;
using DataPoints.Queries.Extensions;
using DataPoints.Subscriptions.Helper;
using DataPoints.Types.Extensions;
using DataPoints.WebAPI.Commond;
using DataPoints.WebAPI.Mapping;
using GraphQL.Server.Ui.Playground;
using HotChocolate.Execution.Options;
using HotChocolate.Subscriptions;

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

builder.Services.AddSingleton<ITopicEventSender, DefaultTopicEventSender>();
builder.Services.AddSingleton<ITopicEventReceiver, DefaultTopicEventReceiver>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithExposedHeaders("X-Subscription-Id"); ;
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
//app.UseMiddleware<GraphQLRequestLoggingMiddleware>();

app.UseCors("AllowAll");
app.UseWebSockets();
app.UseRouting();

app.UseGraphQLPlayground("/ui/playground", new PlaygroundOptions
{
    GraphQLEndPoint = "/graphql",
    SubscriptionsEndPoint = "/graphql", // Same endpoint for WebSocket
    //PlaygroundSettings = new Dictionary<string, object>
    //{
    //    { "request.credentials", "same-origin" }
    //}
});


app.MapGraphQL();



app.Run();