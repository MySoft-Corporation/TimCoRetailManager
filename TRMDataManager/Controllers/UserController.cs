using Microsoft.AspNet.Identity;
using POSDataManager.Library.DataAccess;
using POSDataManager.Library.Models;
using System.Linq;
using System.Web.Http;

namespace POSDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            UserData userData = new UserData();
            string userId = RequestContext.Principal.Identity.GetUserId();
            return userData.GetUserById(userId).First();
        }
    }
}
