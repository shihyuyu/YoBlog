using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace YoBlog
{
    public class DBHelper
    {
        private static string _ConnectionString = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL"]);

        static public DynamicParameters pa = new DynamicParameters();
        static public void ClearPa()
        {
            pa.RemoveUnused = true;
            //pa = new DynamicParameters();
        }

        static public dynamic queryOne(string sql, object param)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                var output = conn.Query(sql, param).ToList();
                if (output.Count == 1)
                {
                    return output.First();
                }
                else
                {
                    return null;
                }
            }
        }

        static public List<T> query<T>(string sql)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                var output = conn.Query<T>(sql).ToList();
                return output;
            }
        }
        static public IEnumerable<dynamic> query(string sql)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                return conn.Query(sql);
            }
        }
        static public List<T> query<T>(string sql, object param)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                var output = conn.Query<T>(sql, param).ToList();
                return output;
            }
        }
        static public IEnumerable<dynamic> query(string sql, object param)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                return conn.Query(sql, param);
            }
        }
        static public int execute(string sql, object param)
        {
            using (var conn = new SqlConnection(_ConnectionString))
            {
                int output = conn.Execute(sql, param);
                return output;
            }
        }
        //交易
        public static int transaction(string[] sql, object[] param)
        {
            int ret = 0;
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Open();

                IDbTransaction tran = conn.BeginTransaction("Transaction");
                try
                {
                    int i = 0;
                    foreach (string s in sql)
                    {
                        conn.Execute(s, param[i], tran);
                        i++;
                    }

                    tran.Commit();
                    ret = i;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    ret = 0;
                }

                conn.Close();
            }

            return ret;
        }
    }

    public class MessageMgt
    {
        public int MsgID { get; set; }
        public string Msg { get; set; }
        public dynamic Data { get; set; }
    }
}