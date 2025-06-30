using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SyncDeal.Communication.Responses;
using SyncDeal.Exceptions;
using SyncDeal.Exceptions.Errors;

namespace SyncDeal.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is SyncDealException)
            {
                HandleException(context);
            } else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleException(ExceptionContext context)
        {

            var syncDealException = context.Exception as SyncDealException;

            var errorResponse = new ResponseErrorDTO(syncDealException.GetErrors());

            context.HttpContext.Response.StatusCode = syncDealException!.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorDTO(ResourceErrorMessages.UNKNOW_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
