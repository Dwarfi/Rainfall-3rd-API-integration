using GeniuseeTestTask.Models.Rainfall;
using Microsoft.AspNetCore.Diagnostics;

namespace GeniuseeTestTask.Handlers;

public class AppExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var response = new ErrorResponse
        {
            Message = exception.Message
        };

        var streamWriter = new StreamWriter(httpContext.Response.Body);

        await streamWriter.WriteAsync(response.ToString());
        await streamWriter.DisposeAsync();

        return true;
    }
}