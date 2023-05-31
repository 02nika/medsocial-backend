using Entities.ErrorModel;
using Entities.Exceptions.CommonExceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Medsocial.Solution.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    var error = new ErrorDetail
                        { StatusCode = context.Response.StatusCode, Message = contextFeature.Error.Message };

                    await context.Response.WriteAsync(error.ToString());
                }
            });
        });
    }
}