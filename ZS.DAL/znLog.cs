using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZS.DB;
using ZS.KIT;

namespace ZS.DAL
{
    /// <summary>
    /// 数据访问类
    /// </summary>
    public partial class znLog
    {
        public znLog()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znLog");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znLog(");
            strSql.Append("UserName,LoginIP,LoginTime,Log)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@LoginIP,@LoginTime,@Log)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,255),
					new SqlParameter("@LoginIP", SqlDbType.NVarChar,255),
					new SqlParameter("@LoginTime", SqlDbType.NVarChar,255),
					new SqlParameter("@Log", SqlDbType.NVarChar,0)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.LoginIP;
            parameters[2].Value = model.LoginTime;
            parameters[3].Value = model.Log;

            //DBNull
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }

            int rows = znSqlDb.ExeNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znLog set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("LoginIP=@LoginIP,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("Log=@Log");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,255),
					new SqlParameter("@LoginIP", SqlDbType.NVarChar,255),
					new SqlParameter("@LoginTime", SqlDbType.NVarChar,255),
					new SqlParameter("@Log", SqlDbType.NVarChar,0),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.LoginIP;
            parameters[2].Value = model.LoginTime;
            parameters[3].Value = model.Log;
            parameters[4].Value = model.ID;

            //DBNull
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }

            int rows = znSqlDb.ExeNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = znSqlDb.ExeNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znLog ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = znSqlDb.ExeNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZS.Model.znLog GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,LoginIP,LoginTime,Log from znLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znLog model = new ZS.Model.znLog();
            DataSet ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZS.Model.znLog DataRowToModel(DataRow row)
        {
            ZS.Model.znLog model = new ZS.Model.znLog();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["LoginIP"] != null)
                {
                    model.LoginIP = row["LoginIP"].ToString();
                }
                if (row["LoginTime"] != null && row["LoginTime"].ToString() != "")
                {
                    model.LoginTime = row["LoginTime"].ToString();
                }
                if (row["Log"] != null)
                {
                    model.Log = row["Log"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,LoginIP,LoginTime,Log ");
            strSql.Append(" from znLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from znLog where ID>0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public Model.znLog GetModel(string UserName)
        {
            string sql = "select top 2 ID,UserName,LoginIP,LoginTime,Log from znLog where UserName=@UserName order by ID desc";
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)
			};
            parameters[0].Value = UserName;
            DataSet ds = znSqlDb.ExeDataSet(sql, parameters);
            if (ds.Tables[0].Rows.Count <= 1)
            {
                return null;
            }
            else
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
        }
        
    }
}
