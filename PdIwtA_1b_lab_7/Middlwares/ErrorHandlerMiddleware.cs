using Microsoft.AspNetCore.Http;
using test_7.Exceptions;
using System.Threading.Tasks;

namespace test_7.Middlwares
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
