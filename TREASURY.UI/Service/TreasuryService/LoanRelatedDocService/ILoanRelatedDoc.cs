using TREASURY.UI.Models.LoanRelatedDoc;

namespace TREASURY.UI.Service.TreasuryService.LoanRelatedDocService
{
    public interface ILoanRelatedDoc
    {
        public Task<List<LoanRelatedDocView>> GetData(int bankid, int unitid);
        public Task<IEnumerable<LoanRelatedDocView>> GetDataByID(int id);
        public Task<Tuple<string, string>> Save(TBLLOANRELATEDDOC model);
        public Task<Tuple<string, string>> Update(TBLLOANRELATEDDOC model);
        public Task<Tuple<string, string>> Delete(int id,int enroll);
    }
}

