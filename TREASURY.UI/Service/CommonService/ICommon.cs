using TREASURY.UI.Models.CommonModel;


namespace TREASURY.UI.Service.CommonService
{
    public interface ICommon
    {
        IQueryable<DropDownBind> GetUnit();
        IQueryable<DropDownBind> GetLoanNumber(string prefix);
        IQueryable<DocumentStatus> GetStatusData();
        IQueryable<Account> GetAccountInfo();
        IQueryable<DropDownBind> GetBankInfoByUnit(int unitid);
        IQueryable<DropDownBind> GetCurrency();
        IQueryable<DropDownBind> GetLoanType();

    }
}


