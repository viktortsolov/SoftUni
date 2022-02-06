using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute(Method httpMethod)
            => HttpMethod = httpMethod;

        public Method HttpMethod { get; }

    }
}
