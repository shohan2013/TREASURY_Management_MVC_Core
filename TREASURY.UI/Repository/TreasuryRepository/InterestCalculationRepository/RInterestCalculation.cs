using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reactive;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Models.Treasury;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;

namespace TREASURY.UI.Repository.TreasuryRepository.InterestCalculationRepository
{
    public class RInterestCalculation : IInterestCalculation
    {
        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RInterestCalculation(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }

        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);

                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.IC00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.IC.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                SqlParameter UNITID = new SqlParameter("@UNITID", unitid);
                SqlParameter DOCUMENTCREATEDBY = new SqlParameter("@DOCUMENTCREATEDBY", enroll);


                var MSG = new SqlParameter
                {
                    ParameterName = "@MSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                var STATUSMSG = new SqlParameter
                {
                    ParameterName = "@STATUSMSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw("Exec SPINTERESTCALCULATIONDELETE @ID,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@UNITID,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    ID, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, UNITID, DOCUMENTCREATEDBY, MSG, STATUSMSG);


                strMsg = MSG.Value.ToString();
                strStatusMsg = STATUSMSG.Value.ToString();
                return Tuple.Create(strMsg, strStatusMsg);
            }
            catch (Exception ex)
            {
                //_common.ErrorLog("", ex.ToString(), enumIMPSubMenu.SQ00001.ToString(), enumIMPProcessName.SQ.ToString(), unitid, enroll, "");
            }
            return null;
        }

        public IQueryable<InterestCalculationViewModel> GetData(int lenderunitid,int borrowerunitid,int enroll)
        {
            try
            {
                SqlParameter LENDERUNITID = new SqlParameter("@LENDERUNITID", lenderunitid);
                SqlParameter BORROWWERUNITID = new SqlParameter("@BORROWWERUNITID", borrowerunitid);
                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.IC00001.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter CREATEDBY = new SqlParameter("@CREATEDBY", enroll);
                return _context.InterestCalculationView.FromSqlRaw("Exec SPGETLENDERBORROWERINFO @LENDERUNITID,@BORROWWERUNITID,@MODULECODE,@DOCSTATUS,@CREATEDBY", LENDERUNITID, BORROWWERUNITID,MODULECODE,DOCSTATUS, CREATEDBY);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Tuple<string, string> Save(InterestCalculationModel master)
        {
            try
            {
                SqlParameter LENDERUNITID = new SqlParameter("@LENDERUNITID", master.LENDERUNITID);
                SqlParameter BORROWERUNITID = new SqlParameter("@BORROWERUNITID", master.BORROWERUNITID);
                SqlParameter AMOUNT = new SqlParameter("@AMOUNT", master.AMOUNT);
                SqlParameter STARTDATE = new SqlParameter("@STARTDATE", master.STARTDATE);
                SqlParameter ENDDATE = new SqlParameter("@ENDDATE", master.ENDDATE);
                SqlParameter NOOFDAYS = new SqlParameter("@NOOFDAYS", master.NOOFDAYS);
                SqlParameter INTERESTRATE = new SqlParameter("@INTERESTRATE", master.INTERESTRATE);
                SqlParameter INTERESTAMT = new SqlParameter("@INTERESTAMT", master.INTERESTAMT);
                SqlParameter DETAILS = new SqlParameter("@DETAILS", master.DETAILS==null ? "":master.DETAILS);


                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.IC00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.IC.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                SqlParameter DOCUMENTCREATEDBY = new SqlParameter("@DOCUMENTCREATEDBY", master.CREATEDBY);
                SqlParameter UNITID = new SqlParameter("@UNITID", master.UNITID);

                var MSG = new SqlParameter
                {
                    ParameterName = "@MSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                var STATUSMSG = new SqlParameter
                {
                    ParameterName = "@STATUSMSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw("Exec SPINSERTINTERESTCALCULATION @LENDERUNITID,@BORROWERUNITID,@AMOUNT,@STARTDATE,@ENDDATE,@NOOFDAYS,@INTERESTRATE,@INTERESTAMT,@DETAILS,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@UNITID,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    LENDERUNITID, BORROWERUNITID, AMOUNT, STARTDATE, ENDDATE, NOOFDAYS, INTERESTRATE, INTERESTAMT, DETAILS, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY,UNITID,MSG, STATUSMSG);



                strMsg = MSG.Value.ToString();
                strStatusMsg = STATUSMSG.Value.ToString();
                return Tuple.Create(strMsg, strStatusMsg);
            }
            catch (Exception ex)
            {
               // _common.ErrorLog("", ex.ToString(), enumIMPSubMenu.SQ00001.ToString(), enumIMPProcessName.SQ.ToString(), 0, master.CREATEDBY, "");
            }
            return null;
        }

        public Tuple<string, string> Update(InterestCalculationModel master)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", master.ID);
                SqlParameter LENDERUNITID = new SqlParameter("@LENDERUNITID", master.LENDERUNITID);
                SqlParameter BORROWERUNITID = new SqlParameter("@BORROWERUNITID", master.BORROWERUNITID);
                SqlParameter AMOUNT = new SqlParameter("@AMOUNT", master.AMOUNT);
                SqlParameter STARTDATE = new SqlParameter("@STARTDATE", master.STARTDATE);
                SqlParameter ENDDATE = new SqlParameter("@ENDDATE", master.ENDDATE);
                SqlParameter NOOFDAYS = new SqlParameter("@NOOFDAYS", master.NOOFDAYS);
                SqlParameter INTERESTRATE = new SqlParameter("@INTERESTRATE", master.INTERESTRATE);
                SqlParameter INTERESTAMT = new SqlParameter("@INTERESTAMT", master.INTERESTAMT);
                SqlParameter DETAILS = new SqlParameter("@DETAILS", master.DETAILS == null ? "" : master.DETAILS);


                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.IC00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.IC.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                SqlParameter DOCUMENTCREATEDBY = new SqlParameter("@DOCUMENTCREATEDBY", master.CREATEDBY);


                var MSG = new SqlParameter
                {
                    ParameterName = "@MSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                var STATUSMSG = new SqlParameter
                {
                    ParameterName = "@STATUSMSG",
                    Size = 100,
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw("Exec SPIUPDATEINTERESTCALCULATION @ID,@LENDERUNITID,@BORROWERUNITID,@AMOUNT,@STARTDATE,@ENDDATE,@NOOFDAYS,@INTERESTRATE,@INTERESTAMT,@DETAILS,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    ID,LENDERUNITID, BORROWERUNITID, AMOUNT, STARTDATE, ENDDATE, NOOFDAYS, INTERESTRATE, INTERESTAMT, DETAILS, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY, MSG, STATUSMSG);


                strMsg = MSG.Value.ToString();
                strStatusMsg = STATUSMSG.Value.ToString();
                return Tuple.Create(strMsg, strStatusMsg);
            }
            catch (Exception ex)
            {
                // _common.ErrorLog("", ex.ToString(), enumIMPSubMenu.SQ00001.ToString(), enumIMPProcessName.SQ.ToString(), 0, master.CREATEDBY, "");
            }
            return null;
        }

        public IQueryable<InterestCalculationModel> ViewDetails(int id, int enroll)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InterestCalculationViewModel> ViewMaster(int id,int enroll)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);
                SqlParameter ENROLL = new SqlParameter("@CREATEDBY", enroll);
                return _context.InterestCalculationView.FromSqlRaw("Exec SPGETLENDERBORROWERINFOBYID @ID,@CREATEDBY", ID,ENROLL);
            }
            catch (Exception)
            {

            }
            return null;
        }

      
    }
}
