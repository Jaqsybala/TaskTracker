using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskTracker.Logic.Exceptions;

namespace TaskTracker.API.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            if (context.Exception is NotFoundException notFoundException)
            {
                context.Result = new ObjectResult(notFoundException.Message)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };

                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new ObjectResult("Упс, что-то пошло не так....")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.ExceptionHandled = true;
            }

        }
    }
}
