using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Middleware
{
    public class IdParameterCatch
    {
        private readonly RequestDelegate _next;
        public IdParameterCatch(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path;
            string[] splittedPath = path.Split("/");

            var s = context.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;

            var rol = context.User.IsInRole("Admin");

            if (splittedPath[1] == s || !rol)
            {
                context.Response.StatusCode = 403;
            }
            await _next.Invoke(context);
        }

    }
}

