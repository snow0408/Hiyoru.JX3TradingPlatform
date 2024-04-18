using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClient
{
    public static class SqlDataReaderExts
    {
        public static string GetString(this SqlDataReader reader, string columnName)
        {
            try
            {
                string value = reader[columnName].ToString();
                return value;
            }
            catch (Exception ex)
            {
                string message = $"GetString發生錯誤, columnName={columnName}";
                throw new Exception(message, ex);
            }
        }
        public static int GetInt(this SqlDataReader reader, string columnName, int defaultValue = 0)
        {
            int index;
            try
            {
                index = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(index))
                {
                    return defaultValue;
                }
                else
                {
                    int value = reader.GetInt32(index);
                    return value;
                }
            }
            catch (Exception ex)
            {
                string message = $"GetInt發生錯誤, columnName={columnName}";
                throw new Exception(message, ex);
            }

        }
        public static DateTime GetDatetime(this SqlDataReader reader, string columnName)
        {
            int index;
            try
            {
                index = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(index))
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return reader.GetDateTime(index);
                }
            }
            catch (Exception ex)
            {
                string message = $"GetDatetime發生錯誤, columnName={columnName}";
                throw new Exception(message, ex);
            }
        }

    }
}
