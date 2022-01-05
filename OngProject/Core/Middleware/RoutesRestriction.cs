using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Middleware
{
    public class RoutesRestriction
    {
        private readonly RequestDelegate _next;
        public RoutesRestriction(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            List<string> methods = new List<string>();
            methods.Add("put");
            methods.Add("post");
            methods.Add("patch");
            methods.Add("delete");
            var method = context.Request.Method;

            List<string> paths = new List<string>();
            //mustToAddRoute?
            string path = context.Request.Path;

            if (methods.Contains(method.ToLower()) && paths.Contains(path.ToLower()))
            {
                if (!context.User.IsInRole("Admin"))
                {
                    context.Response.StatusCode = 401;
                }
            }
            await _next.Invoke(context);
        }
    }

}
