using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace POSDataManager.Library
{
     internal  class SqlDataAccess
    {
        public string GetConnectionString(string connectionString) {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
        public List<T> LoadDate<T,U> (string storedProcedure,U paramaters,string connectionString)
        {
            string myString = GetConnectionString(connectionString);
            using (IDbConnection dbConnection = new SqlConnection(myString))
            {

                    List<T> rows = dbConnection.Query<T>(storedProcedure, paramaters, commandType: CommandType.StoredProcedure).ToList();
                    return rows;
  
            
            }
        }
        public void SaveData<T>(string storedProcedure, T paramaters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Execute(storedProcedure, paramaters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
