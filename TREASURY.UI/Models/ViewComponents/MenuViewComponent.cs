using TREASURY.UI.Service.MenuService;
using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Models.Menu;
using TREASURY.UI.Models.SecurityModel;

namespace TREASURY.UI.Models.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMenu _menu;
        List<Menus> submenulist;
        public MenuViewComponent(IMenu menu, IHttpContextAccessor httpContextAccessor)
        {
            _menu = menu;
            _httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                var vUser = _httpContextAccessor.HttpContext.Session.GetString("Enroll");
                if (vUser == null)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                }
                else
                {
                    submenulist = _menu.GetMenuList((int)HttpContext.Session.GetInt32("Enroll")).ToList();
                    return View("Index", submenulist);
                }
            }
            catch (Exception)
            {
               
            }
            return View("Index", submenulist); 
        }
    }
}
