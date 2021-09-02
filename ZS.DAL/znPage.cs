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
    public partial class znPage
    {
        public znPage()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znPage");
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
        /// 获取名称
        /// </summary>
        public string GetTitle(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from znPage where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;
            return znConvert.ObjectToStr(znSqlDb.ExeScalar(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 获取默认记录
        /// </summary>
        public int GetDefaultID(int categoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from znPage where CategoryID in (select ID from znCategory where Path like '%," + categoryID + ",%') and isCheck=1 order by SortID desc, ID asc");
            return znConvert.ObjToInt(znSqlDb.ExeScalar(strSql.ToString()), 0);
        }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znPage(");
            strSql.Append("CategoryID,Title,Content,SortID,LinkUrl,isUrl,UserName,PostTime,isCheck)");
            strSql.Append(" values (");
            strSql.Append("@CategoryID,@Title,@Content,@SortID,@LinkUrl,@isUrl,@UserName,@PostTime,@isCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@isUrl", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.SortID;
            parameters[4].Value = model.LinkUrl;
            parameters[5].Value = model.isUrl;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.PostTime;
            parameters[8].Value = model.isCheck;

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
        public bool Update(ZS.Model.znPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znPage set ");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("SortID=@SortID,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("isUrl=@isUrl,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PostTime=@PostTime,");
            strSql.Append("isCheck=@isCheck");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@isUrl", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.SortID;
            parameters[4].Value = model.LinkUrl;
            parameters[5].Value = model.isUrl;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.PostTime;
            parameters[8].Value = model.isCheck;
            parameters[9].Value = model.ID;

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
            strSql.Append("update znPage set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znPage ");
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
            strSql.Append("delete from znPage ");
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
        public ZS.Model.znPage GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,CategoryID,Title,Content,SortID,LinkUrl,isUrl,UserName,PostTime,isCheck from znPage ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znPage model = new ZS.Model.znPage();
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
        public ZS.Model.znPage DataRowToModel(DataRow row)
        {
            ZS.Model.znPage model = new ZS.Model.znPage();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CategoryID"] != null && row["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(row["CategoryID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["isUrl"] != null && row["isUrl"].ToString() != "")
                {
                    model.isUrl = int.Parse(row["isUrl"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
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
            strSql.Append("select ID,CategoryID,Title,Content,SortID,LinkUrl,isUrl,UserName,PostTime,isCheck ");
            strSql.Append(" from znPage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int categoryID, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CategoryID,Title,Content,SortID,LinkUrl,isUrl,isCheck,UserName,PostTime,CategoryTitle from znPageView where ID>0");
            if (categoryID > 0)
            {
                strSql.Append(" and CategoryID in (select ID from znCategory where Path like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CategoryID,Title,Content,SortID,LinkUrl,isUrl,isCheck,UserName,PostTime,CategoryTitle from znPageView where ID>0");
            if (categoryID > 0)
            {
                strSql.Append(" and CategoryID in (select ID from znCategory where Path like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }

        
    }
}
