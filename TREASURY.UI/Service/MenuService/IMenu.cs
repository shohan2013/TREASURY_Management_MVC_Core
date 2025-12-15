using TREASURY.UI.Models.Menu;


namespace TREASURY.UI.Service.MenuService
{
    public interface IMenu 
    {
        public IQueryable<Menus> GetMenuList(int enroll);
    }
}
