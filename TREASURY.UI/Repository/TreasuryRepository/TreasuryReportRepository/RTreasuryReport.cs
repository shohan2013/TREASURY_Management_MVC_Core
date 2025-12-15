using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Web.WebPages;
using TREASURY.UI.Models.TreasuryReport;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.TreasuryReportService;

namespace TREASURY.UI.Repository.TreasuryRepository.TreasuryReportRepository
{
    public class RTreasuryReport : ITreasuryReport
    {
        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RTreasuryReport(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }


        public IQueryable<TreasuryReportModel> GetData(int lenderunitid, string startdate, string enddate)
        {
            try
            {
                SqlParameter LENDERUNITID = new SqlParameter("@LENDERUNITID", lenderunitid);
                SqlParameter STARTDATE = new SqlParameter("@STARTDATE", startdate);
                SqlParameter ENDDATE = new SqlParameter("@ENDDATE", enddate);
                return _context.TreasuryReportModel.FromSqlRaw("Exec SPGETLENDERSUMMARYAMT @LENDERUNITID,@STARTDATE,@ENDDATE", LENDERUNITID, STARTDATE, ENDDATE);
            }
            catch (Exception)
            {

            }
            return null;
        }


    }
}
