using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZS.DB;
using ZS.KIT;

namespace ZS.DAL
{
    /// <summary>
    /// 数据访问类:znRoleValue
    /// </summary>
    public partial class znRoleValue
    {
        public znRoleValue()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znRoleValue");
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
        public bool Add(ZS.Model.znRoleValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znRoleValue(");
            strSql.Append("RoleID,ModuleID,ActionList)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@ModuleID,@ActionList)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ActionList", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.ActionList;

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
        public bool Update(ZS.Model.znRoleValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znRoleValue set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("ModuleID=@ModuleID,");
            strSql.Append("ActionList=@ActionList");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ActionList", SqlDbType.NVarChar,255),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.ModuleID;
            parameters[2].Value = model.ActionList;
            parameters[3].Value = model.ID;

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
        public bool Delete(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znRoleValue ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;

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
        /// 得到一个对象实体
        /// </summary>
        public ZS.Model.znRoleValue GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RoleID,ModuleID,ActionList from znRoleValue ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znRoleValue model = new ZS.Model.znRoleValue();
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
        public ZS.Model.znRoleValue DataRowToModel(DataRow row)
        {
            ZS.Model.znRoleValue model = new ZS.Model.znRoleValue();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["ModuleID"] != null && row["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(row["ModuleID"].ToString());
                }
                if (row["ActionList"] != null)
                {
                    model.ActionList = row["ActionList"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RoleID,ModuleID,ActionList ");
            strSql.Append(" from znRoleValue where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;
            return znSqlDb.ExeDataSet(strSql.ToString(), parameters);
        }

    }
}

