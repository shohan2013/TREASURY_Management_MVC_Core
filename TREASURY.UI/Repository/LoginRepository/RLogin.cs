using TREASURY.UI.Models.AuthModel;
using TREASURY.UI.Models.CommonModel;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.Login;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TREASURY.UI.Repository.LoginRepository
{
    public class RLogin : ILogin
    {

        private DBSecurityDbContext _context;
        private FileServerModel server = new FileServerModel();


        public RLogin(DBSecurityDbContext context)
        {
            _context = context;
        }


        public IQueryable<LoginModel> CheckLogin(string username,string password)
        {
            SqlParameter Type = new SqlParameter("@Type", 2);
            SqlParameter UserName = new SqlParameter("@UserName", username == null ? "" : username);
            SqlParameter Password = new SqlParameter("@Password", password==null? "" : password);

            return _context.Login.FromSqlRaw("Exec SPLogin @Type,@UserName,@Password", Type,UserName, Password);
        }
    }
}
