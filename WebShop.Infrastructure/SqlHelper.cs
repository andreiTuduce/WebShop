using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

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
                List<object> results = new List<object>();
                List<T> objectsToReturn = new List<T>();
                PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

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
                                StoreObject(objectsToReturn, propertyInfos, reader);
                            }
                        }
                    }
                }

                return objectsToReturn;
            }
            catch (Exception ex)
            {
                throw ThrowThis(ex, sql);
            }
        }

        private static void StoreObject<T>(List<T> objectsToReturn, PropertyInfo[] propertyInfos, SqlDataReader reader)
        {
            T objectToAdd = (T)Activator.CreateInstance(typeof(T), new object[] { });

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldName = reader.GetName(i);

                PropertyInfo propertyInfo = propertyInfos.FirstOrDefault(prop => prop.Name.ToLower() == fieldName.ToLower());

                if (propertyInfo != null)
                {
                    if (reader[i] != DBNull.Value)
                    {
                        propertyInfo.SetValue(objectToAdd, reader[i], null);
                    }
                }
            }

            objectsToReturn.Add(objectToAdd);
        }

        private static Exception ThrowThis(Exception ex, string sql)
        {
            return new Exception("Error while executing query : " + sql, ex);
        }
    }
}
