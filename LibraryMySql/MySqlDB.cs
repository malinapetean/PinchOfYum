using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryMySql
{
    public class MySqlDB
    {
        public List<T> LoadData<T, U>(string command, U parameters, string connection)
        {
            using (IDbConnection db = new MySqlConnection(connection))
            {
                List<T> res = db.Query<T>(command, parameters).ToList();
                return res;
            }
        }

        public void SaveData<T>(string command, T parameters, string connection)
        {
            using (IDbConnection db = new MySqlConnection(connection))
            {
                db.Execute(command, parameters);
            }
        }
    }
}
