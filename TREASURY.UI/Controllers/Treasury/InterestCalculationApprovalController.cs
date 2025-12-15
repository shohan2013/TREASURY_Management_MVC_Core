using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;

namespace TREASURY.UI.Controllers.Treasury
{
    public class InterestCalculationApprovalController : Controller
    {
        UserInfo userinfo = new UserInfo();
        private readonly IInterestCalculationApproval _obj;
        private readonly ICommon objcommon;

        public InterestCalculationApprovalController(IInterestCalculationApproval obj, ICommon ic)
        {
            _obj = obj;
            objcommon = ic;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetApprovalData(string statusid)
        {
            userinfo.Enroll = (int)HttpContext.Session.GetInt32("Enroll");
            userinfo.UnitID = (int)HttpContext.Session.GetInt32("UnitID");
            var li = _obj.GetApprovalData(userinfo.Enroll, userinfo.UnitID, statusid);
            return Json(li);
        }


        [HttpPost]
        public JsonResult Rejected(int id, string remarks)
        {
            userinfo.Enroll = (int)HttpContext.Session.GetInt32("Enroll");
            userinfo.UnitID = (int)HttpContext.Session.GetInt32("UnitID");
            var li = _obj.Rejected(userinfo.UnitID, EnumTreasurySubMenu.IC00001.ToString(), userinfo.Enroll, id, remarks); // parameter should be come from user session.
            return Json(li);
            
        }

        [HttpPost]
        public JsonResult Approve(int id, string remarks)
        {
            userinfo.Enroll = (int)HttpContext.Session.GetInt32("Enroll");
            userinfo.UnitID = (int)HttpContext.Session.GetInt32("UnitID");
            var li = _obj.Approve(userinfo.UnitID, EnumTreasurySubMenu.IC00001.ToString(), userinfo.Enroll, id, 0, remarks); // parameter should be come from user session.
            return Json(li);
        }
    }


}
