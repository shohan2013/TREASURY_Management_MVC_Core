using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Models.SecurityModel;
using TREASURY.UI.Service.CommonService;
using Microsoft.AspNetCore.Mvc;

namespace TREASURY.UI.Controllers
{
    [CustomAuthorize]
    public class CommonController : Controller
    {
        
        private readonly ICommon objcommon;
        UserInfo userinfo = new UserInfo();

        public CommonController(ICommon common)
        {
            objcommon = common;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUnit()
        {
            var li = objcommon.GetUnit();
            return Json(li);
        }

        [HttpGet]
        public JsonResult GetLoanNumber(string prefix)
        {
            var li = objcommon.GetLoanNumber(prefix);
            return Json(li);
        }


        [HttpGet]
        public JsonResult GetBankInfoByUnit(int unitid)
        {
            var li = objcommon.GetBankInfoByUnit(unitid);
            return Json(li);
        }

        [HttpGet]
        public JsonResult GetStatusData()
        {
            var li = objcommon.GetStatusData(); // parameter should be come from user session.
            return Json(li);
        }

        [HttpGet]
        public JsonResult GetLoanType()
        {
            var li = objcommon.GetLoanType(); // parameter should be come from user session.
            return Json(li);
        }

        [HttpGet]
        public JsonResult GetCurrency()
        {
            var li = objcommon.GetCurrency(); // parameter should be come from user session.
            return Json(li);
        }

        [HttpGet]
        public JsonResult GetAccInfo()
        {
            var li = objcommon.GetAccountInfo();
            var result = new { Result = li, LoginUrl = EnamProcess.APILOGIN, UploadMultiple = EnamProcess.APIUPLOADMULTIPLEFILE, DownloadMultiple = EnamProcess.APIDOWNLOADMULTIPLEFILE };
            return Json(result);
        }
    }
}


