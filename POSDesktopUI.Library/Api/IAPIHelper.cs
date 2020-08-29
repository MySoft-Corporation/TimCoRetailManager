using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace POSDesktopUI.Library.Api
{
    public interface IAPIHelper
    {

        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);

    }
}