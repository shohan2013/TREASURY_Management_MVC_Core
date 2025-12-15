using TREASURY.UI.Models.Menu;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Service.MenuService;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TREASURY.UI.Repository.MenuRepository
{
    public class RMenu : IMenu
    {
        private DBSecurityDbContext _context;
        public RMenu(DBSecurityDbContext context)
        {
            _context = context;
        }
        public IQueryable<Menus> GetMenuList(int enroll)
        {
            try
            {
                SqlParameter Enroll = new SqlParameter("@Enroll", enroll);
                return _context.Menu.FromSqlRaw("Exec SPGETMENULIST @Enroll", Enroll);
            }
            catch (Exception) { 
            
            }
            finally
            { }
            return null;
        }
    }
}
