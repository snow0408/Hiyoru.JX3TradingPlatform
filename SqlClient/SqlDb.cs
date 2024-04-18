using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClient
{
    public class SqlDb
    {
        public static string GetConnectionString(string keyOfConn)
        {
            try
            {
                string conn = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConn].ToString();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception($"找不到名稱為{keyOfConn}的連線字串, 請檢查是否正確");
            }
        }

        public static SqlConnection GetConnection(string keyOfConn)
        {
            string connStr = GetConnectionString(keyOfConn);
            return new SqlConnection(connStr);
        }

        public static List<T> Search<T>(string keyOfConn,
                                        Func<SqlDataReader, T> funcAssembler,
                                        string sql,
                                        params SqlParameter[] parameters)//泛型method
        {
            string connString = GetConnectionString(keyOfConn);
            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();

                    List<T> dataSet = new List<T>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = funcAssembler(reader);
                            dataSet.Add(record);
                        }
                    }

                    return dataSet;
                }
            }
        }

        public static int Create(string keyOfConn, string sql, params SqlParameter[] parameters)
        {
            string connString = GetConnectionString(keyOfConn);
            sql += ";SELECT SCOPE_Identity()";

            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();

                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
        }

        public static void UpdateOrDelect(string keyOfConn, string sql, params SqlParameter[] parameters)
        {
            string connString = GetConnectionString(keyOfConn);

            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static T Get<T>(string keyOfConn,
                                Func<SqlDataReader, T> funcAssembler,
                                string sql,
                                params SqlParameter[] parameters)
        {
            string connString = GetConnectionString(keyOfConn);
            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            T record = funcAssembler(reader);
                            return record;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }

    }
}
