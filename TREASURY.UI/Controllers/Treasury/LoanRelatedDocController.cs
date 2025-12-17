using Microsoft.AspNetCore.Mvc;
using TREASURY.UI.Models.LoanRelatedDoc;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.LoanRelatedDocService;

namespace TREASURY.UI.Controllers.Treasury
{
    public class LoanRelatedDocController : Controller
    {
        private readonly ICommon _common;
        private readonly ILoanRelatedDoc _loanRelatedDoc;

        public LoanRelatedDocController(ICommon common, ILoanRelatedDoc loanRelatedDoc)
        {
            this._common = common;
            _loanRelatedDoc = loanRelatedDoc;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetData(int bankid)
        {
            var result = await _loanRelatedDoc.GetData(bankid, 0);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetDataByID(int id)
        {
            var result = await _loanRelatedDoc.GetDataByID(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TBLLOANRELATEDDOC master)
        {
            master.CreatedBy = (int)HttpContext.Session.GetInt32("Enroll");
            var result = await _loanRelatedDoc.Save(master);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(TBLLOANRELATEDDOC master)
        {
            master.CreatedBy = (int)HttpContext.Session.GetInt32("Enroll");
            var result = await _loanRelatedDoc.Update(master);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteMaster(int id)
        {
            var result = await _loanRelatedDoc.Delete(id, (int)HttpContext.Session.GetInt32("Enroll"));
            return Ok(result);
        }
    }
}
