using TREASURY.UI.Models.LoanFacilityModel;
using TREASURY.UI.Models.Treasury;

namespace TREASURY.UI.Service.TreasuryService.LimitFacilityService
{
    public interface ILimitFacility
    {
        IQueryable<LoanFacilityViewModel> GetData(int unitid,int createdby);
        IQueryable<LoanFacilityViewModel> GetDataByID(int id);
        public Tuple<string, string> DeleteMaster(int id,int unitid,int enroll);
        public Tuple<string, string> Save(LoanFacilityModel master);
        public Tuple<string, string> Update(LoanFacilityModel master);
    }
}
