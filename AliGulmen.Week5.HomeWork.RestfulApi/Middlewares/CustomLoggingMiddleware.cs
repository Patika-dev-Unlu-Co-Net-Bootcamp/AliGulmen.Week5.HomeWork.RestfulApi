using AliGulmen.Week5.HomeWork.RestfulApi.Services.LoggerService;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Middlewares
{

  
    public class CustomLoggingMiddleware
	{

		private readonly RequestDelegate _next;
		private readonly ILoggerService _loggerService;

        public CustomLoggingMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
		{

				string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
			_loggerService.Log(message);

			await _next(context);

				message = "[Request] HTTP "
					+ context.Request.Method + " - "
					+ context.Request.Path
					+ " responded " + context.Response.StatusCode;
			_loggerService.Log(message);


		}


	}


}
