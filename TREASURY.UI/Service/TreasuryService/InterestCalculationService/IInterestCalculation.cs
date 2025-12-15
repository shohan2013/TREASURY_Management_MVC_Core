
using TREASURY.UI.Models.Treasury;

namespace TREASURY.UI.Service.TreasuryService.InterestCalculationService
{
    public interface IInterestCalculation
    {
        IQueryable<InterestCalculationViewModel> GetData(int lenderunitid,int borrowerunitid,int enroll);
        IQueryable<InterestCalculationViewModel> ViewMaster(int id, int enroll);
        IQueryable<InterestCalculationModel> ViewDetails(int id, int enroll);
        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll);
        public Tuple<string, string> Save(InterestCalculationModel master);
        public Tuple<string, string> Update(InterestCalculationModel master);
    }
}
