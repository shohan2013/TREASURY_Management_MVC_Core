using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TREASURY.UI.Models.BankLoan;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.BankLoanService;

namespace TREASURY.UI.Repository.TreasuryRepository.BankLoanRepository
{
    public class RBankLoan : IBankLoan
    {

        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RBankLoan(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }

        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);

                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.LF00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.LF.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.REJC.ToString());
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

                _context.Database.ExecuteSqlRaw("Exec SPBANKLOANDELETE @ID,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@UNITID,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
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

        public IQueryable<BankLoanViewModel> GetData(int bankid,int enroll)
        {

            try
            {
                SqlParameter BANKID = new SqlParameter("@BANKID", bankid);
                return _context.BankLoanViewModel.FromSqlRaw("Exec SPGETBANKLOANLIST @BANKID", BANKID);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public IQueryable<BankLoanViewModel> GetDataByID(int id)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);
                return _context.BankLoanViewModel.FromSqlRaw("Exec SPGETBANKLOANBYID @ID", ID);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Tuple<string, string> Save(BankLoanModel master)
        {
            try
            {
                SqlParameter LENDERBANKID = new SqlParameter("@LENDERBANKID", master.LENDERBANKID);
                SqlParameter BORROWERUNITID = new SqlParameter("@BORROWERUNITID", master.BORROWERUNITID);
                SqlParameter LOANTYPEID = new SqlParameter("@LOANTYPEID", master.LOANTYPEID);
                SqlParameter LOANAMOUNT = new SqlParameter("@LOANAMOUNT", master.LOANAMOUNT);
                SqlParameter CURRENCYID = new SqlParameter("@CURRENCYID", master.CURRENCYID);
                SqlParameter CONRATE = new SqlParameter("@CONRATE", master.CONRATE);
                SqlParameter ISSUEDATE = new SqlParameter("@ISSUEDATE", master.ISSUEDATE);
                SqlParameter MATURITYDATE = new SqlParameter("@MATURITYDATE", master.MATURITYDATE);

                SqlParameter INTERESTRATE = new SqlParameter("@INTERESTRATE", master.INTERESTRATE);
                SqlParameter LOANNUMBER = new SqlParameter("@LOANNUMBER", master.LOANNUMBER);
                SqlParameter NARRATION = new SqlParameter("@NARRATION", master.NARRATION);


                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.BL00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.BL.ToString());
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

                _context.Database.ExecuteSqlRaw("Exec SPINSERTBANKLOAN @LENDERBANKID,@BORROWERUNITID,@LOANTYPEID,@LOANAMOUNT,@CURRENCYID,@CONRATE,@ISSUEDATE,@MATURITYDATE,@INTERESTRATE, @LOANNUMBER,@NARRATION,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@UNITID,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    LENDERBANKID, BORROWERUNITID, LOANTYPEID, LOANAMOUNT, CURRENCYID, CONRATE, ISSUEDATE, MATURITYDATE, INTERESTRATE, LOANNUMBER, NARRATION, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY, UNITID, MSG, STATUSMSG);



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

        public Tuple<string, string> Update(BankLoanModel master)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", master.ID);
                SqlParameter LENDERBANKID = new SqlParameter("@LENDERBANKID", master.LENDERBANKID);
                SqlParameter BORROWERUNITID = new SqlParameter("@BORROWERUNITID", master.BORROWERUNITID);
                SqlParameter LOANTYPEID = new SqlParameter("@LOANTYPEID", master.LOANTYPEID);
                SqlParameter LOANAMOUNT = new SqlParameter("@LOANAMOUNT", master.LOANAMOUNT);
                SqlParameter CURRENCYID = new SqlParameter("@CURRENCYID", master.CURRENCYID);
                SqlParameter CONRATE = new SqlParameter("@CONRATE", master.CONRATE);
                SqlParameter ISSUEDATE = new SqlParameter("@ISSUEDATE", master.ISSUEDATE);
                SqlParameter MATURITYDATE = new SqlParameter("@MATURITYDATE", master.MATURITYDATE);
                SqlParameter INTERESTRATE = new SqlParameter("@INTERESTRATE", master.INTERESTRATE);
                SqlParameter LOANNUMBER = new SqlParameter("@LOANNUMBER", master.LOANNUMBER);
                SqlParameter NARRATION = new SqlParameter("@NARRATION", master.NARRATION);
                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.BL00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.BL.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.EDIT.ToString());
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

                _context.Database.ExecuteSqlRaw("Exec SPUPDATEBANKLOAN @ID,@LENDERBANKID,@BORROWERUNITID,@LOANTYPEID,@LOANAMOUNT,@CURRENCYID,@CONRATE,@ISSUEDATE,@MATURITYDATE,@INTERESTRATE, @LOANNUMBER,@NARRATION,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@UNITID,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    ID,LENDERBANKID, BORROWERUNITID, LOANTYPEID, LOANAMOUNT, CURRENCYID, CONRATE, ISSUEDATE, MATURITYDATE, INTERESTRATE, LOANNUMBER, NARRATION, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY, UNITID, MSG, STATUSMSG);



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
    }
}
