using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers.Filters
{
    public class AuthorizationFilter: Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                Log4netLogger.Log("這裡是filter");
                if (context.Filters.Any(item => item is IAllowAnonymous))
                    return;
                var token = context.HttpContext.Request.Headers["Token"];
                if (token != "123456")
                    context.Result = new UnauthorizedResult();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
