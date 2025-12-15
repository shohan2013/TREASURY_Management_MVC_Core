using Azure.Core;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Data;
using System.Web.Mvc;


namespace TREASURY.UI.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Module, AllowMultiple = false, Inherited = true)]
    public class SecuritySettingAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
