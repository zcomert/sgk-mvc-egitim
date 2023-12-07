using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StoreApp.Infrastructure.ActionFilters;

public class ModelStateValidator : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        List<String> errors = context
        .ModelState
        .Values
        .SelectMany(x => 
            x.Errors.Select(e => e.ErrorMessage))
        .ToList();

        if(context.Controller is Controller controller)
        {
            controller.ViewData["errors"] = errors;
            // refactor
            context.Result = new ViewResult()
            {
                ViewName = "_ErrorView",
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }
        else
        {
            context.Result = new BadRequestObjectResult(errors);
        }
    }
}