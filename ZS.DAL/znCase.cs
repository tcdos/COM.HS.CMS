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
    public partial class znCase
    {
        public znCase()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znCase");
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
        /// 获得名称
        /// </summary>
        public string GetTitle(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from znCase");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int, 4)
            };
            parameters[0].Value = ID;

            string title = Convert.ToString(znSqlDb.ExeScalar(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 获取默认ID
        /// </summary>
        public int GetDefaultID()
        {
            string strSql = "select top 1 ID from znCase where isCheck=1  order by isTop desc,SortID desc,PostTime desc,ID desc";
            return znConvert.ObjToInt(znSqlDb.ExeScalar(strSql.ToString()), 0);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znCase(");
            strSql.Append("CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime)");
            strSql.Append(" values (");
            strSql.Append("@CategoryID,@Title,@Source,@SortID,@Hits,@SmallPic,@Summary,@Content,@LinkUrl,@isUrl,@isTop,@isElite,@isCheck,@UserName,@PostTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@Source", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@SmallPic", SqlDbType.NVarChar,255),
					new SqlParameter("@Summary", SqlDbType.NText),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@isUrl", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@isElite", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Source;
            parameters[3].Value = model.SortID;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.SmallPic;
            parameters[6].Value = model.Summary;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.LinkUrl;
            parameters[9].Value = model.isUrl;
            parameters[10].Value = model.isTop;
            parameters[11].Value = model.isElite;
            parameters[12].Value = model.isCheck;
            parameters[13].Value = model.UserName;
            parameters[14].Value = model.PostTime;

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
        public bool Update(ZS.Model.znCase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znCase set ");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Source=@Source,");
            strSql.Append("SortID=@SortID,");
            strSql.Append("Hits=@Hits,");
            strSql.Append("SmallPic=@SmallPic,");
            strSql.Append("Summary=@Summary,");
            strSql.Append("Content=@Content,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("isUrl=@isUrl,");
            strSql.Append("isTop=@isTop,");
            strSql.Append("isElite=@isElite,");
            strSql.Append("isCheck=@isCheck,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PostTime=@PostTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@Source", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@SmallPic", SqlDbType.NVarChar,255),
					new SqlParameter("@Summary", SqlDbType.NText),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@isUrl", SqlDbType.Int,4),
					new SqlParameter("@isTop", SqlDbType.Int,4),
					new SqlParameter("@isElite", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Source;
            parameters[3].Value = model.SortID;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.SmallPic;
            parameters[6].Value = model.Summary;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.LinkUrl;
            parameters[9].Value = model.isUrl;
            parameters[10].Value = model.isTop;
            parameters[11].Value = model.isElite;
            parameters[12].Value = model.isCheck;
            parameters[13].Value = model.UserName;
            parameters[14].Value = model.PostTime;
            parameters[15].Value = model.ID;

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
            strSql.Append("update znCase set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znCase ");
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
            strSql.Append("delete from znCase ");
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
        public ZS.Model.znCase GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime from znCase ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znCase model = new ZS.Model.znCase();
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
        public ZS.Model.znCase DataRowToModel(DataRow row)
        {
            ZS.Model.znCase model = new ZS.Model.znCase();
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
                if (row["Source"] != null)
                {
                    model.Source = row["Source"].ToString();
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["Hits"] != null && row["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(row["Hits"].ToString());
                }
                if (row["SmallPic"] != null)
                {
                    model.SmallPic = row["SmallPic"].ToString();
                }
                if (row["Summary"] != null)
                {
                    model.Summary = row["Summary"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["isUrl"] != null && row["isUrl"].ToString() != "")
                {
                    model.isUrl = int.Parse(row["isUrl"].ToString());
                }
                if (row["isTop"] != null && row["isTop"].ToString() != "")
                {
                    model.isTop = int.Parse(row["isTop"].ToString());
                }
                if (row["isElite"] != null && row["isElite"].ToString() != "")
                {
                    model.isElite = int.Parse(row["isElite"].ToString());
                }
                if (row["isCheck"] != null && row["isCheck"].ToString() != "")
                {
                    model.isCheck = int.Parse(row["isCheck"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["PostTime"] != null)
                {
                    model.PostTime = row["PostTime"].ToString();
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
            strSql.Append("select ID,CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime ");
            strSql.Append(" from znCase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime,CategoryTitle from znCaseView where ID>0 ");
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
            strSql.Append("select ID,CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime,CategoryTitle from znCaseView where ID>0");
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

        /// <summary>
        /// 按照指定页数查询数据
        /// </summary>
        public DataSet GetPageList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            StringBuilder baseSql = new StringBuilder();
            baseSql.Append("select ID,CategoryID,Title,Source,SortID,Hits,SmallPic,Summary,Content,LinkUrl,isUrl,isTop,isElite,isCheck,UserName,PostTime,CategoryTitle from znCaseView where ID>0");
            if (categoryID > 0)
            {
                baseSql.Append(" and CategoryID in (select ID from znCategory where Path like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                baseSql.Append(strWhere);
            }
            StringBuilder allSql = new StringBuilder();
            if (sortFiled.Trim() != "")
            {
                allSql.Append(baseSql.ToString());
                allSql.Append(" order by " + sortFiled);
            }
            else
            {
                allSql = baseSql;
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(baseSql.ToString())));
            return znSqlDb.ExeDataSet(allSql.ToString(), pageIndex, pageSize, recordCount);
        }

    }
}
