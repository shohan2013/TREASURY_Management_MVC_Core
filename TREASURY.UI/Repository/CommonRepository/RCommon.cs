using AspDotNet.FTPHelper;
using Microsoft.AspNetCore.Http;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Http;

using System.Net;
using System.Security.Cryptography.Xml;
using System.Diagnostics;


namespace TREASURY.UI.Repository.CommonRepository
{
    public class RCommon : ICommon
    {
        private DBSecurityDbContext _context;

        //private FileServerModel server=new FileServerModel();
        private ICommon _common;
        string strMsg = "";
        private IHttpContextAccessor _httpContextAccessor;

        public RCommon(DBSecurityDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _httpContextAccessor = httpContextAccessor; 
        }

        public IQueryable<Account> GetAccountInfo()
        {
            SqlParameter ROOTMODULE = new SqlParameter("@ROOTMODULE", enumIMPRootModule.CODE0002.ToString());
            return _context.Account.FromSqlRaw("Exec GETACCOUNTINFO @ROOTMODULE", ROOTMODULE);
        }

        public IQueryable<DropDownBind> GetUnit()
        {
            return _context.DropDownBind.FromSqlRaw("Exec SPGETUNITALL");
        }

        public IQueryable<DocumentStatus> GetStatusData()
        {
            return _context.DocumentStatus.FromSqlRaw("Exec SPGETDOCUMENTSTATUS");
        }

        public IQueryable<DropDownBind> GetBankInfoByUnit(int unitid)
        {
            SqlParameter UNITID = new SqlParameter("@UNITID", unitid);
            return _context.DropDownBind.FromSqlRaw("Exec SPGETBANKINFOBYUNIT @UNITID", UNITID);
        }

        public IQueryable<DropDownBind> GetCurrency()
        {
            return _context.DropDownBind.FromSqlRaw("Exec SPGETCURRENCY");
        }

        public IQueryable<DropDownBind> GetLoanType()
        {
            return _context.DropDownBind.FromSqlRaw("Exec SPGETLOANTYPE");
        }

        public IQueryable<DropDownBind> GetLoanNumber(string prefix)
        {
            SqlParameter PREFIX = new SqlParameter("@PREFIX", prefix);
            return _context.DropDownBind.FromSqlRaw("Exec SPGETLOANNUMBER @PREFIX", PREFIX);
        }


    }
}

