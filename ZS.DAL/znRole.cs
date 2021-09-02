using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZS.KIT;
using ZS.DB;

namespace ZS.DAL
{
    /// <summary>
    /// 数据访问类:znRole
    /// </summary>
    public partial class znRole
    {
        public znRole()
        { }

        /// <summary>
        /// 检测角色名称是否存在
        /// </summary>
        public bool Exists(string roleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znRole");
            strSql.Append(" where RoleName=@RoleName");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = roleName;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znRole");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取角色名称
        /// </summary>
        public string GetName(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleName from znRole");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            string name = Convert.ToString(znSqlDb.ExeScalar(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znRole(");
            strSql.Append("RoleName)");
            strSql.Append(" values (");
            strSql.Append("@RoleName)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.RoleName;

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
        public bool Update(ZS.Model.znRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znRole set ");
            strSql.Append("RoleName=@RoleName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,255),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.ID;

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
            strSql.Append("delete from znRole ");
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
            strSql.Append("delete from znRole ");
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
        public ZS.Model.znRole GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RoleName from znRole ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znRole model = new ZS.Model.znRole();
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
        public ZS.Model.znRole DataRowToModel(DataRow row)
        {
            ZS.Model.znRole model = new ZS.Model.znRole();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
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
            strSql.Append("select ID,RoleName ");
            strSql.Append(" from znRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,RoleName ");
            strSql.Append(" from znRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RoleName from znRole where ID>0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }
    }
}

