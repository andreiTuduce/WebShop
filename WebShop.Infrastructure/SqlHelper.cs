using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebShop.Infrastructure
{
    internal static class SqlHelper
    {
        internal static int ExecuteNonQuery(IConfig config, string sql)
        {
            try
            {
                int result;

                using (SqlConnection connection = new SqlConnection(config.ConnectionString))
                {
                    using (SqlCommand sqlCommand = connection.CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = sql;

                        connection.Open();

                        result = sqlCommand.ExecuteNonQuery();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ThrowThis(ex, sql);
            }
        }

        internal static List<T> Select<T>(IConfig config, string sql)
        {
            try
            {
                List<T> result = new List<T>();

                using (SqlConnection connection = new SqlConnection(config.ConnectionString))
                {
                    using (SqlCommand sqlCommand = connection.CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = sql;

                        connection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {

                                    //Map the objects and put the correct values from the DB in the model
                                    result.Add((T)reader.GetValue(i));
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ThrowThis(ex, sql);
            }
        }

        private static Exception ThrowThis(Exception ex, string sql)
        {
            return new Exception("Error while executing query : " + sql, ex);
        }
    }
}
