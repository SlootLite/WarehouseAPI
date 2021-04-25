using App.API.Responses;
using App.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = String.Empty;

            if (exception is ItemAlreadyExistException)
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exception is ItemNotFoundException)
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                if (env.IsDevelopment())
                    stackTrace = exception.StackTrace;
            }

            string result;
            if (!env.IsDevelopment())
            {
                result = JsonConvert.SerializeObject(new BaseResponse { ErrorMessage = message });
            }
            else
            {
                result = JsonConvert.SerializeObject(new DevelopmentResponse { ErrorMessage = message, StackTrace = stackTrace });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
