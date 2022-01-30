using SUHttpServer.Common;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;

namespace SUHttpServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable() => this.routes = new()
            {
                [Method.GET] = new Dictionary<string, Response>(),
                [Method.POST] = new Dictionary<string, Response>(),
                [Method.PUT] = new Dictionary<string, Response>(),
                [Method.DELETE] = new Dictionary<string, Response>()
            };

        public IRoutingTable Map(
            string url,
            Method method,
            Response response)
        => method switch
        {
            Method.GET => this.MapGet(url, response),
            Method.POST => this.MapPost(url, response),
            _ => throw new InvalidOperationException($"Method '{method} is not supported.'")
        };

        public IRoutingTable MapGet(
            string url,
            Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.GET][url] = response;

            return this;
        }

        public IRoutingTable MapPost(
            string url,
            Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.POST][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
