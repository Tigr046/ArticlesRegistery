using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorization : Attribute, IAuthorizationFilter
    {
        List<string> allowedRoles = new List<string>();
        public CustomAuthorization(string Roles)
        {
            allowedRoles = Roles.Split(',').ToList();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            foreach(string allowedRole in allowedRoles)
            {
                if (context.HttpContext.User.IsInRole(allowedRole))
                {
                    return;
                }
            }
            context.Result = new ForbidResult(CookieAuthenticationDefaults.AuthenticationScheme);
            
        }
    }
}
