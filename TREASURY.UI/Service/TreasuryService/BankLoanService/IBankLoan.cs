using TREASURY.UI.Models.BankLoan;
using TREASURY.UI.Models.LoanFacilityModel;

namespace TREASURY.UI.Service.TreasuryService.BankLoanService
{
    public interface IBankLoan
    {
        IQueryable<BankLoanViewModel> GetData(int unitid, int createdby);
        IQueryable<BankLoanViewModel> GetDataByID(int id);
        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll);
        public Tuple<string, string> Save(BankLoanModel master);
        public Tuple<string, string> Update(BankLoanModel master);
    }
}
