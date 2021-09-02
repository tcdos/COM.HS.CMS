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
    public partial class znUser
    {
        private readonly ZS.DAL.znModule dalModule = new ZS.DAL.znModule();

        public znUser()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znUser");
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
        /// 是否存在该列
        /// </summary>
        public bool Exists(string columnName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znUser");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,255)
			};
            parameters[0].Value = columnName;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znUser(");
            strSql.Append("UserName,UserPwd,RoleID,Purview,isCheck)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@RoleID,@Purview,@isCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@Purview", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.RoleID;
            parameters[3].Value = model.Purview;
            parameters[4].Value = model.isCheck;

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
        public bool Update(ZS.Model.znUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znUser set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPwd=@UserPwd,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("Purview=@Purview,");
            strSql.Append("isCheck=@isCheck");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@Purview", SqlDbType.Int,4),
                    new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.RoleID;
            parameters[3].Value = model.Purview;
            parameters[4].Value = model.isCheck;
            parameters[5].Value = model.ID;

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
            strSql.Append("update znUser set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znUser ");
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
            strSql.Append("delete from znUser ");
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
        public ZS.Model.znUser GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,UserName,UserPwd,RoleID,Purview,isCheck from znUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znUser model = new ZS.Model.znUser();
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
        public Model.znUser GetModel(string UserName, string UserPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID from znUser");
            strSql.Append(" where UserName=@UserName and UserPwd=@UserPwd and isCheck=1");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;

            object obj = znSqlDb.ExeScalar(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZS.Model.znUser DataRowToModel(DataRow row)
        {
            ZS.Model.znUser model = new ZS.Model.znUser();
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
                if (row["UserPwd"] != null)
                {
                    model.UserPwd = row["UserPwd"].ToString();
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["Purview"] != null && row["Purview"].ToString() != "")
                {
                    model.Purview = int.Parse(row["Purview"].ToString());
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
            strSql.Append("select ID,UserName,UserPwd,RoleID,Purview,isCheck ");
            strSql.Append(" from znUser ");
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
            strSql.Append("select ID,UserName,UserPwd,Purview,RoleID,isCheck from znUser where ID>0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(znSqlDb.ExeScalar(znPageList.CreateCountingSql(strSql.ToString())));
            return znSqlDb.ExeDataSet(znPageList.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), sortFiled));
        }

        /// <summary>
        /// 获取登录用户信息[超级用户]
        /// </summary>
        public DataTable GetUserInfor(string userName, string userPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,UserPwd,Purview from znUser");
            strSql.Append(" where UserName=@UserName and UserPwd=@UserPwd and isCheck=1");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50)};
            parameters[0].Value = userName;
            parameters[1].Value = userPwd;

            DataSet ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取登录用户信息[权限用户]，视图表，以便检测各个模块的操作权限
        /// </summary>
        public DataTable GetUserInfor(string userName, string userPwd, int userPurview)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,UserPwd,Purview,LabelName,ActionList from znUserRoleView");
            strSql.Append(" where UserName=@UserName and UserPwd=@UserPwd and Purview=@Purview and isCheck=1");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@Purview", SqlDbType.Int,4)};
            parameters[0].Value = userName;
            parameters[1].Value = userPwd;
            parameters[2].Value = userPurview;

            DataSet ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取登录用户[一级模块]
        /// </summary>
        public DataTable GetUserModule(string userName, int userPurview, int layerID)
        {
            //return ds.Tables[0]：znUserRoleView视图表与znModule表字段名称保持一致，确保系统导航输出
            DataSet ds = null;
            if (userPurview == 0)
            {
                //超级用户：直接读取系统模块表
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer from znModule where Layer=@LayerID");
                strSql.Append(" order by SortID desc, ID asc");
                SqlParameter[] parameters = {
                    new SqlParameter("@LayerID", SqlDbType.Int,4)};
                parameters[0].Value = layerID;

                ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            }
            else
            {
                //权限用户：读取对应的角色权限模块表（视图）
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer from znUserRoleView where UserName=@UserName and Layer=@LayerID and isCheck=1");
                strSql.Append(" order by SortID desc, ID asc");
                SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@LayerID", SqlDbType.Int,4)};
                parameters[0].Value = userName;
                parameters[1].Value = layerID;

                ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            }
            return ds.Tables[0];
           
        }

        /// <summary>
        /// 获取登录用户指定子模块
        /// </summary>
        public DataTable GetUserModuleList(string userName, int userPurview, int parentID)
        {
            if (userPurview == 0)
                //超级用户：直接读取系统模块表
                return dalModule.GetList(parentID);
            else
                //权限用户：读取对应的角色权限模块表（视图）
                return GetUserRoleModule(userName, parentID);
        }

        /// <summary>
        /// 获取[权限用户]角色所属子模块
        /// </summary>
        private DataTable GetUserRoleModule(string userName, int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList from znUserRoleView where UserName=@UserName");
            strSql.Append(" order by SortID desc, ID asc");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = userName;

            DataTable dt = znSqlDb.ExeDataSet(strSql.ToString(), parameters).Tables[0];
            if (dt == null) { return null; }
            DataTable allDT = dt.Clone();
            GetChilds(dt, allDT, parentID);
            return allDT;
        }

        /// <summary>
        /// 获取所有下级列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable dt, DataTable allDT, int parentID)
        {
            DataRow[] dr = dt.Select("parentID=" + parentID);
            for (int i = 0; i < dr.Length; i++)
            {
                DataRow row = allDT.NewRow();
                row["ID"] = int.Parse(dr[i]["ID"].ToString());
                row["Title"] = dr[i]["Title"].ToString();
                row["LabelName"] = dr[i]["LabelName"].ToString();
                row["LinkUrl"] = dr[i]["LinkUrl"].ToString();
                row["SortID"] = int.Parse(dr[i]["SortID"].ToString());
                row["ParentID"] = int.Parse(dr[i]["ParentID"].ToString());
                row["Path"] = dr[i]["Path"].ToString();
                row["Layer"] = int.Parse(dr[i]["Layer"].ToString());
                row["ActionList"] = dr[i]["ActionList"].ToString();
                allDT.Rows.Add(row);
                this.GetChilds(dt, allDT, int.Parse(dr[i]["ID"].ToString()));
            }
        }

    }
}
