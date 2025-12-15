using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Models.TreasuryReport;

namespace TREASURY.UI.Service.TreasuryService.TreasuryReportService
{
    public interface ITreasuryReport
    {
        IQueryable<TreasuryReportModel> GetData(int lenderunitid, string startdate, string enddate);
    }
}
