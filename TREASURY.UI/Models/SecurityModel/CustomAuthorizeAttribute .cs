using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Policy;


namespace TREASURY.UI.Models.SecurityModel
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        private IHttpContextAccessor _httpContextAccessor;


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _httpContextAccessor = context.HttpContext.RequestServices.GetService<IHttpContextAccessor>();
            //bool authorize = false;
            var actionName = "";
            var controllerName = "";

            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            if (routeData != null)
            {
                if (routeData.Values.ContainsKey("action"))
                {
                    if(routeData.Values.ContainsKey("action"))
                    {
                        actionName = routeData.Values["action"].ToString();
                    }
                    if (routeData.Values.ContainsKey("controller"))
                    {
                        controllerName = routeData.Values["controller"].ToString().ToUpper();
                    }
                    if (controllerName != "LOGIN")
                    {
                        var vUser = _httpContextAccessor.HttpContext.Session.GetString("Enroll");

                        if (vUser == null)
                        {
                            _httpContextAccessor.HttpContext.Response.Clear();
                            _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    { 
                        
                    }

                }
                
            }

        }
    }
}
