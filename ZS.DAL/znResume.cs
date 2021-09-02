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
    public partial class znResume
    {
        public znResume()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znResume");
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
        public bool Add(ZS.Model.znResume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znResume(");
            strSql.Append("PositionID,Author,Sex,Tel,Email,Resume,PostTime,isCheck)");
            strSql.Append(" values (");
            strSql.Append("@PositionID,@Author,@Sex,@Tel,@Email,@Resume,@PostTime,@isCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionID", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Resume", SqlDbType.NText),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4)};
            parameters[0].Value = model.PositionID;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Tel;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Resume;
            parameters[6].Value = model.PostTime;
            parameters[7].Value = model.isCheck;

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
        public bool Update(ZS.Model.znResume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znResume set ");
            strSql.Append("PositionID=@PositionID,");
            strSql.Append("Author=@Author,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Email=@Email,");
            strSql.Append("Resume=@Resume,");
            strSql.Append("PostTime=@PostTime,");
            strSql.Append("isCheck=@isCheck");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PositionID", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Resume", SqlDbType.NText),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PositionID;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Tel;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Resume;
            parameters[6].Value = model.PostTime;
            parameters[7].Value = model.isCheck;
            parameters[8].Value = model.ID;

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
            strSql.Append("update znResume set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znResume ");
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
            strSql.Append("delete from znResume ");
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
        public ZS.Model.znResume GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,PositionID,Author,Sex,Tel,Email,Resume,PostTime,isCheck from znResume ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znResume model = new ZS.Model.znResume();
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
        public ZS.Model.znResume DataRowToModel(DataRow row)
        {
            ZS.Model.znResume model = new ZS.Model.znResume();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PositionID"] != null && row["PositionID"].ToString() != "")
                {
                    model.PositionID = int.Parse(row["PositionID"].ToString());
                }
                if (row["Author"] != null)
                {
                    model.Author = row["Author"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Resume"] != null)
                {
                    model.Resume = row["Resume"].ToString();
                }
                if (row["PostTime"] != null)
                {
                    model.PostTime = row["PostTime"].ToString();
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
            strSql.Append("select ID,PositionID,Author,Sex,Tel,Email,Resume,PostTime,isCheck ");
            strSql.Append(" from znResume ");
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
            strSql.Append("select ID,PositionID,Author,Sex,Tel,Email,Resume,PostTime,isCheck from znResume where ID>0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }
        
    }
}
