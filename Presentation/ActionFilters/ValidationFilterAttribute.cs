﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilters;
public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];

        var param = context.ActionArguments
            .Values
            .FirstOrDefault(p => p != null && p.GetType().Name.EndsWith("Dto"));

        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"obje boş. {controller} action {action}");
            return;
        }
        if (!context.ModelState.IsValid)
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
    }
}
