using TREASURY.UI.Models.BankLoan;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;

namespace TREASURY.UI.Service.TreasuryService.SettlementService
{
    public interface ISettlement
    {
        IQueryable<BankLoanSettlementViewModel> GetDataByID(int id);

        IQueryable<BankLoanSettlementViewModel> GetData(int unitid, int typeid, int createdby);
        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll);
        public Tuple<string, string> Save(BankLoanSettlementModel master);
        public Tuple<string, string> Update(BankLoanSettlementModel master);
    }
}

