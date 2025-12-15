using TREASURY.UI.Models.Dashboard;
using TREASURY.UI.Service.Dashboard;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TREASURY.UI.Repository.Dashboard
{
    public class RDashboard:IDashboard
    {
       // private Context _context;
        public RDashboard()
        {

          //_context = context; 
        }
        public IQueryable<DashboardData> Dashboard(int type)

        {
            //try
            //{
            //  //  SqlParameter ID = new SqlParameter("@ID", id);
            //    SqlParameter TYPE = new SqlParameter("@TYPE", type);
            //    return null;
            //    //return _context.DashboardData.FromSqlRaw("Exec SPDASHBOARD @TYPE",  TYPE);
            //}
            //catch (Exception ex)
            // {
            //    return null;
            //}
            return null;
        }
        public IQueryable<DashboardGraphData> DashBoardGraphBar(int type)

        {
            //try
            //{
            //  //  SqlParameter ID = new SqlParameter("@ID", id);
            //    SqlParameter TYPE = new SqlParameter("@TYPE", type);

            //    ///return _context.DashboardGraphData.FromSqlRaw("Exec SPDASHBOARD @TYPE",  TYPE);
            //    return null;
            //}
            //catch (Exception ex)
            // {
            //    return null;
            //}

            return null;
        }
    }
}
