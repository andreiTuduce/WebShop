using System.Collections.Generic;

namespace WebShop.Infrastructure
{
    public static class DataAccessHelper
    {

        public static void Insert(IConfig config, string sql)
        {
            SqlHelper.ExecuteNonQuery(config, sql);
        }

        public static List<T> Select<T>(IConfig config, string sql)
        {
            return SqlHelper.Select<T>(config, sql);
        }

        public static void Update(IConfig config, string sql)
        {
            SqlHelper.ExecuteNonQuery(config, sql);
        }

        public static void Delete(IConfig config, string sql)
        {
            SqlHelper.ExecuteNonQuery(config, sql);
        }

    }
}
