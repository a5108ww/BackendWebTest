using Microsoft.AspNetCore.Mvc.Filters;

namespace BackendWebProj.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            await next();
        }
    }
}
