using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Repository.TreasuryRepository.InterestCalculationRepository;
using TREASURY.UI.Service.CommonService;

namespace TREASURY.UI.Service.TreasuryService.InterestCalculationService
{
    public interface IInterestCalculationApproval
    {
        string Approve(int unitid, string modeulecode, int enroll, int id, int histryid, string remarks);
        string Rejected(int unitid, string modeulecode, int enroll, int id, string remarks);
        IQueryable<InterestCalculationViewModel> GetApprovalData(int enroll,int unitid, string id);
    }
}
