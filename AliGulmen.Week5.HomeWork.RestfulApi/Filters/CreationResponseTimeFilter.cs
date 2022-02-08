using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Filters
{

    //We will create two filters here.
    //One of them is ActionFilter. because OnActionExecuting method is called before a controller action is executed. (creationTime)
    //Second one is ResultFilter. because OnResultExecuting method is called before a controller action result is executed. (responseTime)
    //and to affect all controllres we will add them to startup.cs
    //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/understanding-action-filters-cs

    public class CreationTimeFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string creationTime = DateTime.Now.ToString();
            context.HttpContext.Response.Headers.Add("CreationTime", creationTime);
        }
    }


    public class ResponseTimeFilter : IResultFilter
    {

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string responseTime = DateTime.Now.ToString();
            context.HttpContext.Response.Headers.Add("ResponseTime", responseTime);
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

      
    }
}
