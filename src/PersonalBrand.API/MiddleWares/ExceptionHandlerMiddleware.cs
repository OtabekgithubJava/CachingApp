using PersonalBrand.Domain.Entities.Models;

namespace PersonalBrand.API.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                _logger.LogError($"{e}\n\n\n");

                await context.Response.WriteAsJsonAsync(new ResponseModel()
                {
                    StatusCode = 500,
                    Message = e.Message
                });
            }
        }
    }
}

