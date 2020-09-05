using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DapperForApi.Middlewares
{
    public class GlobalException
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public GlobalException(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("GlobalException");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // ilk Http Context bilgisinin düþeceði yer.
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, ex.Message);
            }
        }
    }
}