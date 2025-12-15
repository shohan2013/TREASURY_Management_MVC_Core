using TREASURY.UI.Models.AuthModel;
using TREASURY.UI.Models.CommonModel;

namespace TREASURY.UI.Service.Login
{
    public interface ILogin
    {
        IQueryable<LoginModel> CheckLogin(string username,string password);
    }
}
