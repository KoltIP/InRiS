using A.Middleware.Models;
using System.Text.Json;

namespace A.Middleware
{
    public class Middleware
    {
        readonly RequestDelegate next;
        public Middleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse response = null;
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                response = e.ToErrorResponse();
            }
            finally
            {
                if (!(response is null))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
