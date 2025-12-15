using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Repository.TreasuryRepository.InterestCalculationRepository;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;

namespace TREASURY.UI.Controllers.Treasury
{
    public class InterestCalculationController : Controller
    {
        private readonly IInterestCalculation _obj;
        private readonly ICommon _common;
        public InterestCalculationController(IInterestCalculation obj, ICommon common)
        {
            _obj = obj;
            _common = common;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetData(int lenderunitid,int borrowerunitid)
        {
            var li = _obj.GetData(lenderunitid,borrowerunitid,(int)HttpContext.Session.GetInt32("Enroll"));
            return Json(li);
        }


        [HttpGet]
        public JsonResult GetDataByID(int id)
        {
            var li = _obj.ViewMaster(id, (int)HttpContext.Session.GetInt32("Enroll"));
            return Json(li);
        }


        [HttpPost]
        public JsonResult DeleteMaster(int id)
        {
            var li = _obj.DeleteMaster(id, (int)HttpContext.Session.GetInt32("UnitID"), (int)HttpContext.Session.GetInt32("Enroll"));
            return Json(li);
        }

        [HttpPost]
        public JsonResult Save(InterestCalculationModel master)
        {
            master.CREATEDBY = (int)HttpContext.Session.GetInt32("Enroll");
            master.UNITID = (int)HttpContext.Session.GetInt32("UnitID");

            var li = _obj.Save(master);
            return Json(li);
        }

        [HttpPost]
        public JsonResult Update(InterestCalculationModel master)
        {
            master.CREATEDBY = (int)HttpContext.Session.GetInt32("Enroll");

            var li = _obj.Update(master);
            return Json(li);
        }
    }
}
