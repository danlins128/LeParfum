using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LeParfum.Exception;
using LeParfum.Api.DTOs;
using System.Net;

namespace LeParfum.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is LeParfumException leParfumException)
            {
                context.HttpContext.Response.StatusCode = (int) leParfumException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ErrorMessageDto
                {
                    Errors = leParfumException.GetErrorMessages()
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new ErrorMessageDto
                {
                    Errors = ["Unknown error"]
                });
            }
        }
    }
}