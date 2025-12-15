using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TREASURY.UI.Models.BankLoan;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.SettlementService;

namespace TREASURY.UI.Repository.TreasuryRepository.SettlementRepository
{
    public class RSettlementRepository : ISettlement
    {

        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RSettlementRepository(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }


        public Tuple<string, string> DeleteMaster(int id, int unitid, int enroll)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);

                //SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.LF00001.ToString());
                //SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.LF.ToString());
                //SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.REJC.ToString());
                //SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                //SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                //SqlParameter UNITID = new SqlParameter("@UNITID", unitid);
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

                _context.Database.ExecuteSqlRaw("Exec SPBANKLOANRESCHEDULEDDELETE @ID,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT", ID, DOCUMENTCREATEDBY, MSG, STATUSMSG);


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


        public IQueryable<BankLoanSettlementViewModel> GetData(int bankid,int typeid, int createdby)
        {
            try
            {
                SqlParameter BANKID = new SqlParameter("@BANKID", bankid);
                SqlParameter TYPEID = new SqlParameter("@TYPEID", typeid);
                return _context.BankLoanSettlementViewModel.FromSqlRaw("Exec SPGETPAYMENTRESCHEDULED @BANKID,@TYPEID", BANKID, TYPEID);
            }
            catch (Exception)
            {

            }
            return null;
        }


            public IQueryable<BankLoanSettlementViewModel> GetDataByID(int id)
            {
                try
                {
                    SqlParameter ID = new SqlParameter("@ID", id);
                    return _context.BankLoanSettlementViewModel.FromSqlRaw("Exec SPGETPAYMENTRESCHEDULEDBYID @ID", ID);
                }
                catch (Exception)
                {

                }
                return null;
            }


            public Tuple<string, string> Save(BankLoanSettlementModel master)
            {
            try
            {
                SqlParameter CRATE = new SqlParameter("@CRATE", master.CRATE);
                SqlParameter PAYMENT = new SqlParameter("@PAYMENT", master.PAYMENT);
                SqlParameter PAYMENTDATE = new SqlParameter("@PAYMENTDATE", master.PAYMENTDATE==null ? "" : master.PAYMENTDATE);
                SqlParameter RESCHEDULEDPAYMENTDATE = new SqlParameter("@RESCHEDULEDPAYMENTDATE", master.RESCHEDULEDPAYMENTDATE == null ? "" : master.RESCHEDULEDPAYMENTDATE);

                SqlParameter REFID = new SqlParameter("@REFID", master.REFID);
                SqlParameter NARRATION = new SqlParameter("@NARRATION", master.NARRATION);

                //SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.BL00001.ToString());
                //SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.BL.ToString());
                //SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                //SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                //SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                SqlParameter DOCUMENTCREATEDBY = new SqlParameter("@DOCUMENTCREATEDBY", master.CREATEDBY);
                //SqlParameter UNITID = new SqlParameter("@UNITID", master.UNITID);

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

                _context.Database.ExecuteSqlRaw("Exec SPINSERTPAYMENTRESCHEDULEDLOAN @CRATE,@PAYMENT,@PAYMENTDATE,@RESCHEDULEDPAYMENTDATE,@REFID,@NARRATION,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    @CRATE, @PAYMENT, @PAYMENTDATE, @RESCHEDULEDPAYMENTDATE, @REFID, @NARRATION, DOCUMENTCREATEDBY, MSG, STATUSMSG);



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


        public Tuple<string, string> Update(BankLoanSettlementModel master)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", master.ID);
                SqlParameter CRATE = new SqlParameter("@CRATE", master.CRATE);
                SqlParameter PAYMENT = new SqlParameter("@PAYMENT", master.PAYMENT);
                SqlParameter PAYMENTDATE = new SqlParameter("@PAYMENTDATE", master.PAYMENTDATE);
                SqlParameter RESCHEDULEDPAYMENTDATE = new SqlParameter("@RESCHEDULEDPAYMENTDATE", master.RESCHEDULEDPAYMENTDATE);

                SqlParameter REFID = new SqlParameter("@REFID", master.REFID);
                SqlParameter NARRATION = new SqlParameter("@NARRATION", master.NARRATION);

                //SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.BL00001.ToString());
                //SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.BL.ToString());
                //SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                //SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.DEL.ToString());
                //SqlParameter NOTIFICATION = new SqlParameter("@NOTIFICATION", EnumTreasuryNotification.SUBMIT.ToString());
                SqlParameter DOCUMENTCREATEDBY = new SqlParameter("@DOCUMENTCREATEDBY", master.CREATEDBY);
                //SqlParameter UNITID = new SqlParameter("@UNITID", master.UNITID);

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

                _context.Database.ExecuteSqlRaw("Exec SPUPDATEPAYMENTRESCHEDULEDLOAN @ID,@CRATE,@PAYMENT,@PAYMENTDATE,@RESCHEDULEDPAYMENTDATE,@REFID,@NARRATION,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    ID,CRATE, PAYMENT, PAYMENTDATE, RESCHEDULEDPAYMENTDATE, REFID, NARRATION, DOCUMENTCREATEDBY, MSG, STATUSMSG);



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
