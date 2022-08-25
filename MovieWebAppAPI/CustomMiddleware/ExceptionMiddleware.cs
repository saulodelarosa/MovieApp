using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MovieWebAppAPI.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //serilog - to log into flat files.
            _logger.LogInformation("this is custom middleware");
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                /* store informatin into the flat file (any txt file)
                
                

                 */
                var exceptionInformation = new
                {
                    ex.Message,
                    Trace = ex.StackTrace,
                    Type = ex.GetType(),
                    TimeInfo = DateTime.Now,
                    InnerMessage = ex.InnerException?.Message,
                    RequestUrl = httpContext.Request.Path,
                    RequestMethod = httpContext.Request.Method,
                    UserName = httpContext.User.Identity.Name


                };

                _logger.LogError(exceptionInformation.Message);
                _logger.LogError(exceptionInformation.Trace);

            }

            // return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
