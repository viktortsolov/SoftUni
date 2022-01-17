using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> preRenderAction = null) 
            : base(text, ContentType.PlainText)
        {
        }
    }
}
