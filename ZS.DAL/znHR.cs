﻿using System;
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
    public partial class znHR
    {
        public znHR()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znHR");
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
            strSql.Append("select top 1 Title from znHR");
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
            string strSql = "select top 1 ID from znHR where isCheck=1  order by isTop desc,SortID desc,PostTime desc,ID desc";
            return znConvert.ObjToInt(znSqlDb.ExeScalar(strSql.ToString()), 0);
        }

        /// <summary>
        /// 获得类别ID
        /// </summary>
        public int GetCategoryID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 CategoryID from znHR");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int, 4)
            };
            parameters[0].Value = ID;
            return znConvert.ObjToInt(znSqlDb.ExeScalar(strSql.ToString(), parameters), 0);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znHR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znHR(");
            strSql.Append("CategoryID,Title,LimitNum,Address,Salary,Email,Infor,Request,StartDate,EndDate,isTop,isElite,isCheck,UserName,PostTime)");
            strSql.Append(" values (");
            strSql.Append("@CategoryID,@Title,@LimitNum,@Address,@Salary,@Email,@Infor,@Request,@StartDate,@EndDate,@isTop,@isElite,@isCheck,@UserName,@PostTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CategoryID", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,255),
                    new SqlParameter("@LimitNum", SqlDbType.Int,4),
                    new SqlParameter("@Address", SqlDbType.NVarChar,255),
                    new SqlParameter("@Salary", SqlDbType.NVarChar,255),
                    new SqlParameter("@Email", SqlDbType.NVarChar,255),
                    new SqlParameter("@Infor", SqlDbType.NText),
                    new SqlParameter("@Request", SqlDbType.NText),
                    new SqlParameter("@StartDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@isTop", SqlDbType.Int,4),
                    new SqlParameter("@isElite", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostTime", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LimitNum;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Salary;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Infor;
            parameters[7].Value = model.Request;
            parameters[8].Value = model.StartDate;
            parameters[9].Value = model.EndDate;
            parameters[10].Value = model.isTop;
            parameters[11].Value = model.isElite;
            parameters[12].Value = model.isCheck;
            parameters[13].Value = model.UserName;
            parameters[14].Value = model.PostTime;

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
        public bool Update(ZS.Model.znHR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znHR set ");
            strSql.Append("CategoryID=@CategoryID,");
            strSql.Append("Title=@Title,");
            strSql.Append("LimitNum=@LimitNum,");
            strSql.Append("Address=@Address,");
            strSql.Append("Salary=@Salary,");
            strSql.Append("Email=@Email,");
            strSql.Append("Infor=@Infor,");
            strSql.Append("Request=@Request,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("isTop=@isTop,");
            strSql.Append("isElite=@isElite,");
            strSql.Append("isCheck=@isCheck,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PostTime=@PostTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CategoryID", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,255),
                    new SqlParameter("@LimitNum", SqlDbType.Int,4),
                    new SqlParameter("@Address", SqlDbType.NVarChar,255),
                    new SqlParameter("@Salary", SqlDbType.NVarChar,255),
                    new SqlParameter("@Email", SqlDbType.NVarChar,255),
                    new SqlParameter("@Infor", SqlDbType.NText),
                    new SqlParameter("@Request", SqlDbType.NText),
                    new SqlParameter("@StartDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndDate", SqlDbType.NVarChar,50),
                    new SqlParameter("@isTop", SqlDbType.Int,4),
                    new SqlParameter("@isElite", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LimitNum;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Salary;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Infor;
            parameters[7].Value = model.Request;
            parameters[8].Value = model.StartDate;
            parameters[9].Value = model.EndDate;
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
            strSql.Append("update znHR set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znHR ");
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
            strSql.Append("delete from znHR ");
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
        public ZS.Model.znHR GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,CategoryID,Title,LimitNum,Address,Salary,Email,Infor,Request,StartDate,EndDate,isTop,isElite,isCheck,UserName,PostTime from znHR ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znHR model = new ZS.Model.znHR();
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
        public ZS.Model.znHR DataRowToModel(DataRow row)
        {
            ZS.Model.znHR model = new ZS.Model.znHR();
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
                if (row["LimitNum"] != null && row["LimitNum"].ToString() != "")
                {
                    model.LimitNum = int.Parse(row["LimitNum"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Salary"] != null)
                {
                    model.Salary = row["Salary"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Infor"] != null)
                {
                    model.Infor = row["Infor"].ToString();
                }
                if (row["Request"] != null)
                {
                    model.Request = row["Request"].ToString();
                }
                if (row["StartDate"] != null)
                {
                    model.StartDate = row["StartDate"].ToString();
                }
                if (row["EndDate"] != null)
                {
                    model.EndDate = row["EndDate"].ToString();
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
            strSql.Append("select ID,CategoryID,Title,LimitNum,Address,Salary,Email,Infor,Request,StartDate,EndDate,isTop,isElite,isCheck,UserName,PostTime ");
            strSql.Append(" from znHR ");
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
            strSql.Append("select ID,CategoryID,Title,LimitNum,Address,Salary,Email,Infor,Request,StartDate,EndDate,isTop,isElite,isCheck,UserName,PostTime,CategoryTitle from znHRView where ID>0");
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
            strSql.Append("select ID,CategoryID,Title,LimitNum,Address,Salary,Email,Infor,Request,StartDate,EndDate,isTop,isElite,isCheck,UserName,PostTime,CategoryTitle from znHRView where ID>0");
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
