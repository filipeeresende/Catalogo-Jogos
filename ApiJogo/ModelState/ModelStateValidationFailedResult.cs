using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portal_Terceiros_Domain.Settings.ErrorHandler;

namespace Portal_Terceiros_API.Tools.ExceptionHandler
{
    public class ModelStateValidationFailedResult : ObjectResult
    {
        public ModelStateValidationFailedResult(ModelStateDictionary modelState)
            : base(new ErrorResponse(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
