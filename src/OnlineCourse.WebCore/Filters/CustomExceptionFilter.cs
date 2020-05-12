using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineCourse.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OnlineCourse.WebCore.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = context.Exception is DomainException ? 502 : 500;
                context.Result = context.Exception is DomainException domain ?
                    new JsonResult(domain.ErrorMessages) :
                    new JsonResult("An error occurred");
                context.ExceptionHandled = true;

            }
            base.OnException(context);
        }
    }
}
