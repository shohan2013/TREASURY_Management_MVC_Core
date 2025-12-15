using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;

namespace TREASURY.UI.Repository.TreasuryRepository.InterestCalculationRepository
{
    public class RInterestCalculationApproval : IInterestCalculationApproval
    {
        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string Msg = "";

        public RInterestCalculationApproval(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }

        public string Approve(int unitid, string modeulecode, int enroll, int id, int histryid, string remarks)
        {
            try
            {
                SqlParameter HistryID = new SqlParameter("@HistryID", id);
                SqlParameter UnitID = new SqlParameter("@unitid", unitid);
                SqlParameter ModuleCode = new SqlParameter("@ModuleCode", modeulecode);
                SqlParameter Enroll = new SqlParameter("@Enroll", enroll);
                SqlParameter ID = new SqlParameter("@ID", id);
                SqlParameter Remarks = new SqlParameter("@Remarks", remarks == null ? "" : remarks);

                SqlParameter ApproveCode = new SqlParameter("@ApproveCode", EnumTreasuryDocStatus.APPR.ToString());
                SqlParameter ApproveMsg = new SqlParameter("@ApproveMsg", EnumTreasuryMessage.APPR.ToString());
                SqlParameter Notification = new SqlParameter("@Notification", EnumTreasuryNotification.APPR.ToString());
                SqlParameter ProcessName = new SqlParameter("@ProcessName", EnumTreasuryProcess.IC.ToString());

                var outParam = new SqlParameter
                {
                    ParameterName = "@Msg",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw("Exec SPApprove @HistryID,@unitid,@ModuleCode,@Enroll,@ID,@Remarks,@ApproveCode,@ApproveMsg,@Notification,@ProcessName,@Msg output", HistryID, UnitID, ModuleCode, Enroll, ID, Remarks, ApproveCode, ApproveMsg, Notification, ProcessName, outParam);
                Msg = outParam.Value.ToString();
            }
            catch
            {

            }
            finally { }
            return Msg;
        }

        public string Rejected(int unitid, string modeulecode, int enroll, int id, string remarks)
        {
            try
            {
                SqlParameter UnitID = new SqlParameter("@unitid", unitid);
                SqlParameter ModuleCode = new SqlParameter("@ModuleCode", modeulecode);
                SqlParameter Enroll = new SqlParameter("@Enroll", enroll);
                SqlParameter ID = new SqlParameter("@ID", id);
                SqlParameter Remarks = new SqlParameter("@Remarks", remarks == null ? "" : remarks);

                SqlParameter ApproveCode = new SqlParameter("@RejectCode", EnumTreasuryDocStatus.REJC.ToString());
                SqlParameter ApproveMsg = new SqlParameter("@RejectedMsg", EnumTreasuryMessage.REJ.ToString());
                SqlParameter Notification = new SqlParameter("@Notification", EnumTreasuryNotification.REJECT.ToString());
                SqlParameter ProcessName = new SqlParameter("@ProcessName", EnumTreasuryProcess.IC.ToString());


                var outParam = new SqlParameter
                {
                    ParameterName = "@Msg",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw("Exec SPRejected @unitid,@ModuleCode,@Enroll,@ID,@Remarks,@ProcessName,@RejectCode,@RejectedMsg,@Notification,@Msg output", UnitID, ModuleCode, Enroll, ID, Remarks, ProcessName, ApproveCode, ApproveMsg, Notification, outParam);
                Msg = outParam.Value.ToString();
            }
            catch
            {

            }
            finally { }
            return Msg;
        }


        public IQueryable<InterestCalculationViewModel> GetApprovalData(int enroll,int unitid, string id)
        {

            SqlParameter UnitID = new SqlParameter("@unitid", unitid);
            SqlParameter Code = new SqlParameter("@Code", EnumTreasurySubMenu.IC00001.ToString());
            SqlParameter Enroll = new SqlParameter("@Enroll", enroll);
            SqlParameter ID = new SqlParameter("@ID", id);

            return _context.InterestCalculationView.FromSqlRaw("Exec SPGETDATAFORINTERESTAPPROVAL @unitid,@Code,@Enroll,@ID", UnitID, Code, Enroll, ID);
        }
    }
}
