using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;
using TREASURY.UI.Service.TreasuryService.TreasuryReportService;

namespace TREASURY.UI.Controllers.Treasury
{
    public class TreasuryReportController : Controller
    {
        private readonly ITreasuryReport _obj;
        private readonly ICommon _common;
        public TreasuryReportController(ITreasuryReport obj, ICommon common)
        {
            _obj = obj;
            _common = common;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetData(int lenderunitid, string startdate, string enddate)
        {
            var li = _obj.GetData(lenderunitid, startdate, enddate);
            
            return Json(li);
        }

    }
}
