using POSDataManager.Library.Models;
using System.Collections.Generic;

namespace POSDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var p = new { Id };
            var output = sqlDataAccess.LoadDate<UserModel, dynamic>("dbo.spUserLookup", p, "DefaultConnection");
            return output;
        }
    }
}
