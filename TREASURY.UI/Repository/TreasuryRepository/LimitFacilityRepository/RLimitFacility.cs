using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Models.LoanFacilityModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.TreasuryService.LimitFacilityService;

namespace TREASURY.UI.Repository.TreasuryRepository.LimitFacilityRepository
{
    public class RLimitFacility : ILimitFacility
    {

        private DBSecurityDbContext _context;
        private ICommon _common;
        string strMsg = "";
        string strStatusMsg = "";

        public RLimitFacility(DBSecurityDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }
        public Tuple<string, string> DeleteMaster(int id, int unitid,int enroll)
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

                _context.Database.ExecuteSqlRaw("Exec SPLIMITFACILITYDELETE @ID,@MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@UNITID,@DOCUMENTCREATEDBY,@MSG OUTPUT,@STATUSMSG OUTPUT",
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

        public IQueryable<LoanFacilityViewModel> GetData(int unitid, int createdby)
        {
            try
            {
                SqlParameter UNITID = new SqlParameter("@UNITID", unitid);
                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.LF00001.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter CREATEDBY = new SqlParameter("@CREATEDBY", createdby);
                return _context.LoanFacilityViewModel.FromSqlRaw("Exec SPGETLOANFACILITY @UNITID,@MODULECODE,@DOCSTATUS,@CREATEDBY", UNITID, MODULECODE, DOCSTATUS, CREATEDBY);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public IQueryable<LoanFacilityViewModel> GetDataByID(int id)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", id);
                return _context.LoanFacilityViewModel.FromSqlRaw("Exec SPGETLOANFACILITYBYID @ID", ID);
            }
            catch (Exception)
            {

            }
            return null;
        }

        public Tuple<string, string> Save(LoanFacilityModel master)
        {
            try
            {
                SqlParameter INNERUNITID = new SqlParameter("@INNERUNITID", master.INNERUNITID);
                SqlParameter BANKID = new SqlParameter("@BANKID", master.BANKID);
                SqlParameter RAWMATERIALLIMIT = new SqlParameter("@RAWMATERIALLIMIT", master.RAWMATERIALLIMIT);
                SqlParameter LOANLIMIT = new SqlParameter("@LOANLIMIT", master.LOANLIMIT);
                SqlParameter MACHINERYLIMIT = new SqlParameter("@MACHINERYLIMIT", master.MACHINERYLIMIT);
                SqlParameter SHORTTERMLOAN = new SqlParameter("@SHORTTERMLOAN", master.SHORTTERMLOAN);
                SqlParameter OVERDRAFTFACILITY = new SqlParameter("@OVERDRAFTFACILITY", master.OVERDRAFTFACILITY);
                SqlParameter BANKGUARANTEELIMIT = new SqlParameter("@BANKGUARANTEELIMIT", master.BANKGUARANTEELIMIT);

                SqlParameter TIMELOANLIMIT = new SqlParameter("@TIMELOANLIMIT", master.TIMELOANLIMIT);
                SqlParameter TERMLOANLIMIT = new SqlParameter("@TERMLOANLIMIT", master.TERMLOANLIMIT);
                SqlParameter LCSPARESMACHINERYLIMIT = new SqlParameter("@LCSPARESMACHINERYLIMIT", master.LCSPARESMACHINERYLIMIT);

                SqlParameter SODLIMIT = new SqlParameter("@SODLIMIT", master.SODLIMIT);
                SqlParameter SANCTIONREF = new SqlParameter("@SANCTIONREF", master.SANCTIONREF==null ? "" : master.SANCTIONREF);
                SqlParameter EXPIREDATE = new SqlParameter("@EXPIREDATE", master.EXPIREDATE==null ? "" : master.EXPIREDATE);


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

                _context.Database.ExecuteSqlRaw("Exec SPINSERTLIMITFACILITY @INNERUNITID,@BANKID,@RAWMATERIALLIMIT,@LOANLIMIT,@MACHINERYLIMIT,@SHORTTERMLOAN,@OVERDRAFTFACILITY,@BANKGUARANTEELIMIT,@TIMELOANLIMIT, @TERMLOANLIMIT,@LCSPARESMACHINERYLIMIT,@SODLIMIT,@SANCTIONREF,@EXPIREDATE, @MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@UNITID,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    INNERUNITID, BANKID, RAWMATERIALLIMIT, LOANLIMIT, MACHINERYLIMIT, SHORTTERMLOAN, OVERDRAFTFACILITY, BANKGUARANTEELIMIT,TIMELOANLIMIT, TERMLOANLIMIT, LCSPARESMACHINERYLIMIT, SODLIMIT, SANCTIONREF, EXPIREDATE,  MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY, UNITID, MSG, STATUSMSG);



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

        public Tuple<string, string> Update(LoanFacilityModel master)
        {
            try
            {
                SqlParameter ID = new SqlParameter("@ID", master.ID);
                SqlParameter INNERUNITID = new SqlParameter("@INNERUNITID", master.INNERUNITID);
                SqlParameter BANKID = new SqlParameter("@BANKID", master.BANKID);
                SqlParameter RAWMATERIALLIMIT = new SqlParameter("@RAWMATERIALLIMIT", master.RAWMATERIALLIMIT);
                SqlParameter LOANLIMIT = new SqlParameter("@LOANLIMIT", master.LOANLIMIT);
                SqlParameter MACHINERYLIMIT = new SqlParameter("@MACHINERYLIMIT", master.MACHINERYLIMIT);
                SqlParameter SHORTTERMLOAN = new SqlParameter("@SHORTTERMLOAN", master.SHORTTERMLOAN);
                SqlParameter OVERDRAFTFACILITY = new SqlParameter("@OVERDRAFTFACILITY", master.OVERDRAFTFACILITY);
                SqlParameter BANKGUARANTEELIMIT = new SqlParameter("@BANKGUARANTEELIMIT", master.BANKGUARANTEELIMIT);

                SqlParameter TIMELOANLIMIT = new SqlParameter("@TIMELOANLIMIT", master.TIMELOANLIMIT);
                SqlParameter TERMLOANLIMIT = new SqlParameter("@TERMLOANLIMIT", master.TERMLOANLIMIT);
                SqlParameter LCSPARESMACHINERYLIMIT = new SqlParameter("@LCSPARESMACHINERYLIMIT", master.LCSPARESMACHINERYLIMIT);

                SqlParameter SODLIMIT = new SqlParameter("@SODLIMIT", master.SODLIMIT);
                SqlParameter SANCTIONREF = new SqlParameter("@SANCTIONREF", master.SANCTIONREF);
                SqlParameter EXPIREDATE = new SqlParameter("@EXPIREDATE", master.EXPIREDATE);


                SqlParameter MODULECODE = new SqlParameter("@MODULECODE", EnumTreasurySubMenu.LF00001.ToString());
                SqlParameter PROCESSNAME = new SqlParameter("@PROCESSNAME", EnumTreasuryProcess.LF.ToString());
                SqlParameter DOCSTATUS = new SqlParameter("@DOCSTATUS", EnumTreasuryDocStatus.PEND.ToString());
                SqlParameter MESSAGENAME = new SqlParameter("@MESSAGENAME", EnumTreasuryMessage.SAVE.ToString());
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

                _context.Database.ExecuteSqlRaw("Exec SPUPDATELIMITFACILITY @ID,@INNERUNITID,@BANKID,@RAWMATERIALLIMIT,@LOANLIMIT,@MACHINERYLIMIT,@SHORTTERMLOAN,@OVERDRAFTFACILITY,@BANKGUARANTEELIMIT,@TIMELOANLIMIT, @TERMLOANLIMIT,@LCSPARESMACHINERYLIMIT,@SODLIMIT,@SANCTIONREF,@EXPIREDATE, @MODULECODE,@PROCESSNAME,@DOCSTATUS,@MESSAGENAME,@NOTIFICATION,@DOCUMENTCREATEDBY,@UNITID,@MSG OUTPUT,@STATUSMSG OUTPUT",
                    ID,INNERUNITID, BANKID, RAWMATERIALLIMIT, LOANLIMIT, MACHINERYLIMIT, SHORTTERMLOAN, OVERDRAFTFACILITY, BANKGUARANTEELIMIT, TIMELOANLIMIT, TERMLOANLIMIT, LCSPARESMACHINERYLIMIT, SODLIMIT, SANCTIONREF, EXPIREDATE, MODULECODE, PROCESSNAME, DOCSTATUS, MESSAGENAME, NOTIFICATION, DOCUMENTCREATEDBY, UNITID, MSG, STATUSMSG);



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
