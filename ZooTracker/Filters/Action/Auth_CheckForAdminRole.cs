using ZooTracker.DataAccess.IRepo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ZooTracker.Filters.ActionFilters
{
    public class Auth_CheckForAdminRole : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var roles = context.HttpContext.User.FindAll(ClaimTypes.Role); //doesnt quite work.  need to get the value
            context.HttpContext.Items.Add("isAdmin", Guid.NewGuid().ToString());
        }
        
    }
}
