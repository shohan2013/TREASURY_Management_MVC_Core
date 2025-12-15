using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Models.BankLoan;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.BankLoanService;
using TREASURY.UI.Service.TreasuryService.LimitFacilityService;

namespace TREASURY.UI.Controllers.Treasury
{
    public class BankLoanController : Controller
    {
        private readonly IBankLoan _obj;
        private readonly ICommon _common;

        public BankLoanController(IBankLoan obj, ICommon common)
        {
            _obj = obj;
            _common = common;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public JsonResult GetData(int unitid)
        {
            var li = _obj.GetData(unitid, (int)HttpContext.Session.GetInt32("Enroll"));
            return Json(li);
        }


        [HttpGet]
        public JsonResult GetDataByID(int id)
        {
            var li = _obj.GetDataByID(id);
            return Json(li);
        }

        [HttpPost]
        public JsonResult Save(BankLoanModel master)
        {
            master.CREATEDBY = (int)HttpContext.Session.GetInt32("Enroll");
            master.UNITID = (int)HttpContext.Session.GetInt32("UnitID");

            var li = _obj.Save(master);
            return Json(li);
        }


        [HttpPost]
        public JsonResult Update(BankLoanModel master)
        {
            master.CREATEDBY = (int)HttpContext.Session.GetInt32("Enroll");

            var li = _obj.Update(master);
            return Json(li);
        }

        [HttpPost]
        public JsonResult DeleteMaster(int id)
        {
            var li = _obj.DeleteMaster(id, (int)HttpContext.Session.GetInt32("UnitID"), (int)HttpContext.Session.GetInt32("Enroll"));
            return Json(li);
        }

    }
}
