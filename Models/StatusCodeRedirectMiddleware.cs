namespace TP3.Models
{
    public class StatusCodeRedirectMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _locationPath;

        public StatusCodeRedirectMiddleware(RequestDelegate next, string locationPath)
        {
            _next = next;
            _locationPath = locationPath;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                context.Response.Redirect(_locationPath + "/404");
            }
            else if (context.Response.StatusCode >= 400)
            {
                context.Response.Redirect(_locationPath + "/" + context.Response.StatusCode);
            }
        }
    }
    public static class StatusCodeRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseStatusCodeRedirect(this IApplicationBuilder builder, string locationPath)
        {
            return builder.UseMiddleware<StatusCodeRedirectMiddleware>(locationPath);
        }
    }
}
