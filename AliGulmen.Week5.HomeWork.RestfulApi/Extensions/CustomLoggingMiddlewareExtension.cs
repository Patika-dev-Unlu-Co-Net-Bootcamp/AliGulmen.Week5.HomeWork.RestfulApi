using Microsoft.AspNetCore.Builder;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Middlewares
{
	public static class CustomLoggingMiddlewareExtension
	{
	
		public static IApplicationBuilder UseCustomLoggingMiddleware(this IApplicationBuilder builder)
		{

			return builder.UseMiddleware<CustomLoggingMiddleware>();
		}
	}


}
