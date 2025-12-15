
using TREASURY.UI.Models.SecurityModel;
using TREASURY.UI.Service.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace TREASURY.UI.Controllers
{
    [CustomAuthorize]
    public class DashboardController : Controller
    {
        public readonly IDashboard dashboard;
        public DashboardController(IDashboard _dashboard)
        {
            dashboard = _dashboard;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult DashBoard(int  type)
        {
            var li=dashboard.Dashboard(type);

            return Json(li);
        } 
        public JsonResult DashBoardGraphBar(int  type)
        {
            var li=dashboard.DashBoardGraphBar(type);

            return Json(li);
        } 
        public JsonResult DashBoardGraphpie(int  type)
        {
            var li=dashboard.DashBoardGraphBar(type);

            return Json(li);
        } public JsonResult DashBoardGraphBardo(int  type)
        {
            var li=dashboard.DashBoardGraphBar(type);

            return Json(li);
        } public JsonResult DashBoardGraphbarr(int  type)
        {
            var li=dashboard.DashBoardGraphBar(type);

            return Json(li);
        }
       
    }
}
