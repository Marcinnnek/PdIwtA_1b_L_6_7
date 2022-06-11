using Microsoft.AspNetCore.Http;
using PdIwtA_1b.ASP.Exceptions;
using System.Threading.Tasks;

namespace PdIwtA_1b.ASP.Middlwares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next; // następna akcja - następny middleware

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) // metoda iddleware
        {
            try
            {
                await _next(context);
            }
            catch (ProductsAlreadyExistsException e)
            {
                context.Response.StatusCode = StatusCodes.Status402PaymentRequired; // inny kod
            }
            catch (System.Exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
