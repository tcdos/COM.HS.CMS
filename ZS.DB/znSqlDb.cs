using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZS.DB
{
    public abstract class znSqlDb
    {
        //数据库连接字符串
        public static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString();

        /// <summary>
        /// 执行查询语句，返回DataReader
        /// </summary>
        public static SqlDataReader ExeDataReader(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandTimeout = 180;
                        SqlDataReader dr = cmd.ExecuteReader();
                        return dr;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataReader[参数化]
        /// </summary>
        public static SqlDataReader ExeReader(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, strSql, cmdParms);
                        SqlDataReader dr = cmd.ExecuteReader();
                        cmd.Parameters.Clear();
                        return dr;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        public static DataSet ExeDataSet(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataSet ds = new DataSet();
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(strSql, conn))
                {
                    try
                    {
                        da.SelectCommand.CommandTimeout = 180;
                        da.Fill(ds);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet[参数化]
        /// </summary>
        public static DataSet ExeDataSet(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(cmd, conn, null, strSql, cmdParms);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.SelectCommand.CommandTimeout = 180;
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet[参数化/结合事务]
        /// </summary>
        public static DataSet ExeDataSet(SqlConnection conn, SqlTransaction trans, string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommand(cmd, conn, trans, strSql, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.SelectCommand.CommandTimeout = 180;
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet, 用于分页数据查询
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataSet ExeDataSet(string strSql, int pageIndex, int pageSize, int recordCount)
        {
            //总页数
            int totalPage = recordCount / pageSize;
            if (recordCount % pageSize > 0)
            {
                totalPage += 1;
            }
            //当前页数
            if (pageIndex < 1 || pageIndex > totalPage)
            {
                pageIndex = 1;
            }
            //返回当前分页数据源
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(strSql.ToString(), conn);
                    da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "PageList");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataRow
        /// </summary>
        public static DataRow ExeDataRow(string strSql)
        {
            DataTable dt = ExeDataSet(strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataRow[参数化]
        /// </summary>
        public static DataRow ExeDataRow(string strSql, params SqlParameter[] cmdParms)
        {
            DataTable dt = ExeDataSet(strSql, cmdParms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        public static object ExeScalar(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandTimeout = 180;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                            return null;
                        else
                            return obj;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL查询语句[参数化]
        /// </summary>
        public static object ExeScalar(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, strSql, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果
        /// </summary>
        public static object ExeScalar(SqlConnection conn, SqlTransaction trans, string strSql)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, conn))
            {
                try
                {
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL更新语句
        /// </summary>
        public static int ExeNonQuery(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandTimeout = 180;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL更新语句[参数化]
        /// </summary>
        public static int ExeNonQuery(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, strSql, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL更新语句[参数化/事务]
        /// </summary>
        public static int ExeNonQuery(SqlConnection conn, SqlTransaction trans, string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, conn, trans, strSql, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL更新语句[参数化/事务] 
        /// </summary>
        public static object ExeNonQueryObject(SqlConnection conn, SqlTransaction trans, string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, conn, trans, strSql, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    trans.Rollback();
                    throw e;
                }
            }
        }


        /// <summary>
        /// 查询记录是否存在
        /// </summary>
        public static bool Exists(string strSql)
        {
            object obj = ExeScalar(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查询记录是否存在[参数化]
        /// </summary>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = ExeScalar(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 参数处理[中间函数]
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandTimeout = 180;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataSet ds = new DataSet();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                da.SelectCommand.CommandTimeout = 180;
                da.Fill(ds, tableName);
                conn.Close();
                return ds;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storedProcName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 180;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }

    }
}
