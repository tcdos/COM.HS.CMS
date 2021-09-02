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
    public partial class znBanner
    {
        public znBanner()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znBanner");
            strSql.Append(" where ID=@ID");
            if (isCheck)
            {
                strSql.Append(" and isCheck=1");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znBanner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znBanner(");
            strSql.Append("Title,SmallPic,SortID,isCheck)");
            strSql.Append(" values (");
            strSql.Append("@Title,@SmallPic,@SortID,@isCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@SmallPic", SqlDbType.NVarChar,255),
                    new SqlParameter("@SortID", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.SmallPic;
            parameters[2].Value = model.SortID;
            parameters[3].Value = model.isCheck;

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
        public bool Update(ZS.Model.znBanner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znBanner set ");
            strSql.Append("Title=@Title,");
            strSql.Append("SmallPic=@SmallPic,");
            strSql.Append("SortID=@SortID,");
            strSql.Append("isCheck=@isCheck");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@SmallPic", SqlDbType.NVarChar,255),
                    new SqlParameter("@SortID", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.SmallPic;
            parameters[2].Value = model.SortID;
            parameters[3].Value = model.isCheck;
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
        /// 更新一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znBanner set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znBanner ");
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
            strSql.Append("delete from znBanner ");
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
        public ZS.Model.znBanner GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,SmallPic,SortID,isCheck from znBanner ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            ZS.Model.znBanner model = new ZS.Model.znBanner();
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
        public ZS.Model.znBanner DataRowToModel(DataRow row)
        {
            ZS.Model.znBanner model = new ZS.Model.znBanner();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["SmallPic"] != null)
                {
                    model.SmallPic = row["SmallPic"].ToString();
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["isCheck"] != null && row["isCheck"].ToString() != "")
                {
                    model.isCheck = int.Parse(row["isCheck"].ToString());
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
            strSql.Append("select ID,Title,SmallPic,SortID,isCheck ");
            strSql.Append(" from znBanner ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,SmallPic,SortID,isCheck from znBanner where ID>0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }

    }
}
