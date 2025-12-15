

using TREASURY.UI.Models.Dashboard;

namespace TREASURY.UI.Service.Dashboard
{
    public interface IDashboard
    {
        public IQueryable<DashboardData> Dashboard(int type);
        public IQueryable<DashboardGraphData> DashBoardGraphBar(int type);
    }
}
