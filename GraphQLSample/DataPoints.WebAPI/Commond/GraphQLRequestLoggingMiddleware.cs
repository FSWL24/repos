namespace DataPoints.WebAPI.Commond
{
    public class GraphQLRequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GraphQLRequestLoggingMiddleware> _logger;

        public GraphQLRequestLoggingMiddleware(RequestDelegate next, ILogger<GraphQLRequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/graphql"))
            {
                var start = DateTime.UtcNow;
                _logger.LogInformation($"GraphQL Request started at {start}");

                await _next(context);

                var duration = DateTime.UtcNow - start;
                _logger.LogInformation($"GraphQL Request completed in {duration.TotalMilliseconds}ms");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
