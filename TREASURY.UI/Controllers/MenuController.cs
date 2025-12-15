using TREASURY.UI.Models.SecurityModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace TREASURY.UI.Controllers
{
    [CustomAuthorize]
    public class MenuController : Controller
    {
        private readonly IMenu _obj;
        public IActionResult Index()
        {
            return View();
        }

        public MenuController(IMenu obj)
        {
            _obj = obj;
        }

        [HttpGet]
        public JsonResult GetMenuList()
        {
            var li = _obj.GetMenuList(535949); // parameter should be come from user session.
            return Json(li);
        }
    }
}
