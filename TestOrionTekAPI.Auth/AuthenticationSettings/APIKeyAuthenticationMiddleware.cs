using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Auth.AuthenticationSettings
{
    public class APIKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly APIKeySettings _apiKeySettings;

        public APIKeyAuthenticationMiddleware(RequestDelegate next, IOptions<APIKeySettings> apiKeySettings)
        {
            _next = next;
            _apiKeySettings = apiKeySettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["API-KEY-USER"].FirstOrDefault()?.Split(" ").Last();

            if (token == null || token != _apiKeySettings.Key)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }

            await _next(context);
        }
    }

    public static class APIKeyAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKeyAuthenticationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<APIKeyAuthenticationMiddleware>();

            return app;
        }
    }
}
