using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZS.DB;

namespace ZS.DAL
{
    /// <summary>
    /// 数据访问类
    /// </summary>
    public partial class znModule
    {
        public znModule()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znModule");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4)
			};
            parameters[0].Value = ID;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检测模块标签名是否存在
        /// </summary>
        public bool Exists(string labelName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znModule");
            strSql.Append(" where LabelName=@LabelName");
            SqlParameter[] parameters = {
					new SqlParameter("@LabelName", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = labelName;

            return znSqlDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得名称
        /// </summary>
        public string GetTitle(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from znModule");
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
        ///  获得父ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int GetParentId(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ParentID from znModule");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4)
			};
            parameters[0].Value = ID;

            return Convert.ToInt32(znSqlDb.ExeScalar(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znModule model)
        {
            using (SqlConnection conn = new SqlConnection(znSqlDb.connStr))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into znModule(");
                        strSql.Append("Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList)");
                        strSql.Append(" values (");
                        strSql.Append("@Title,@CssName,@LabelName,@LinkUrl,@SortID,@ParentID,@Path,@Layer,@ActionList)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Title", SqlDbType.NVarChar,255),
					            new SqlParameter("@CssName", SqlDbType.NVarChar,50),
					            new SqlParameter("@LabelName", SqlDbType.NVarChar,255),
					            new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					            new SqlParameter("@SortID", SqlDbType.Int,4),
					            new SqlParameter("@ParentID", SqlDbType.Int,4),
					            new SqlParameter("@Path", SqlDbType.NText),
					            new SqlParameter("@Layer", SqlDbType.Int,4),
					            new SqlParameter("@ActionList", SqlDbType.NText)};
                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.CssName;
                        parameters[2].Value = model.LabelName;
                        parameters[3].Value = model.LinkUrl;
                        parameters[4].Value = model.SortID;
                        parameters[5].Value = model.ParentID;
                        parameters[6].Value = model.Path;
                        parameters[7].Value = model.Layer;
                        parameters[8].Value = model.ActionList;

                        //DBNull
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }

                        object obj = znSqlDb.ExeNonQueryObject(conn, trans, strSql.ToString(), parameters);
                        model.ID = Convert.ToInt32(obj);//获取新插入的ID

                        if (model.ParentID > 0)
                        {
                            Model.znModule m = GetModel(conn, trans, Convert.ToInt32(model.ParentID));
                            model.Path = m.Path + model.ID + ",";
                            model.Layer = m.Layer + 1;
                        }
                        else
                        {
                            model.Path = "," + model.ID + ",";
                            model.Layer = 1;
                        }
                        //更新层级
                        znSqlDb.ExeNonQuery(conn, trans, "update znModule set Path='" + model.Path + "', Layer=" + model.Layer + " where id=" + model.ID);
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znModule model)
        {
            using (SqlConnection conn = new SqlConnection(znSqlDb.connStr))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //向下移动
                        if (IsContainNode(model.ID, Convert.ToInt32(model.ParentID)))
                        {
                            //读取当前节点数据
                            ZS.Model.znModule oldModel = GetModel(conn, trans, model.ID);
                            //查找旧父节点数据
                            string class_list = "," + model.ParentID + ",";
                            int class_layer = 1;
                            if (oldModel.ParentID > 0)
                            {
                                //读取当前节点的父节点的数据
                                ZS.Model.znModule oldParentModel = GetModel(conn, trans, Convert.ToInt32(oldModel.ParentID));
                                class_list = oldParentModel.Path + model.ParentID + ",";
                                class_layer = Convert.ToInt32(oldParentModel.Layer) + 1;
                            }
                            //更新当前节点选择的父节点的数据
                            znSqlDb.ExeNonQuery(conn, trans, "update znModule set ParentID=" + oldModel.ParentID + ", Path='" + class_list + "', Layer=" + class_layer + " where id=" + model.ParentID); //带事务
                            //更新当前节点的父节点的所有子节点的数据
                            UpdateChilds(conn, trans, Convert.ToInt32(model.ParentID)); //带事务
                        }
                        //向上移动
                        if (model.ParentID > 0)
                        {
                            ZS.Model.znModule m = GetModel(conn, trans, Convert.ToInt32(model.ParentID));
                            model.Path = m.Path + model.ID + ",";
                            model.Layer = m.Layer + 1;
                        }
                        else
                        {
                            model.Path = "," + model.ID + ",";
                            model.Layer = 1;
                        }

                        //更新当前节点的数据
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update znModule set ");
                        strSql.Append("Title=@Title,");
                        strSql.Append("CssName=@CssName,");
                        strSql.Append("LabelName=@LabelName,");
                        strSql.Append("LinkUrl=@LinkUrl,");
                        strSql.Append("SortID=@SortID,");
                        strSql.Append("ParentID=@ParentID,");
                        strSql.Append("Path=@Path,");
                        strSql.Append("Layer=@Layer,");
                        strSql.Append("ActionList=@ActionList");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Title", SqlDbType.NVarChar,255),
					            new SqlParameter("@CssName", SqlDbType.NVarChar,50),
					            new SqlParameter("@LabelName", SqlDbType.NVarChar,255),
					            new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					            new SqlParameter("@SortID", SqlDbType.Int,4),
					            new SqlParameter("@ParentID", SqlDbType.Int,4),
					            new SqlParameter("@Path", SqlDbType.NText),
					            new SqlParameter("@Layer", SqlDbType.Int,4),
					            new SqlParameter("@ActionList", SqlDbType.NText),
					            new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.CssName;
                        parameters[2].Value = model.LabelName;
                        parameters[3].Value = model.LinkUrl;
                        parameters[4].Value = model.SortID;
                        parameters[5].Value = model.ParentID;
                        parameters[6].Value = model.Path;
                        parameters[7].Value = model.Layer;
                        parameters[8].Value = model.ActionList;
                        parameters[9].Value = model.ID;

                        //DBNull
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }

                        znSqlDb.ExeNonQuery(conn, trans, strSql.ToString(), parameters);

                        //更新当前节点的子节点数据
                        UpdateChilds(conn, trans, model.ID);
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znModule ");
            strSql.Append(" where Path like '%," + ID + ",%' ");
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
        public ZS.Model.znModule GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList from znModule ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znModule model = new ZS.Model.znModule();
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
        public ZS.Model.znModule DataRowToModel(DataRow row)
        {
            ZS.Model.znModule model = new ZS.Model.znModule();
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
                if (row["CssName"] != null)
                {
                    model.CssName = row["CssName"].ToString();
                }
                if (row["LabelName"] != null)
                {
                    model.LabelName = row["LabelName"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["Layer"] != null && row["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(row["Layer"].ToString());
                }
                if (row["ActionList"] != null)
                {
                    model.ActionList = row["ActionList"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.znModule GetModel(SqlConnection conn, SqlTransaction trans, int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList from znModule ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.znModule model = new Model.znModule();
            DataSet ds = znSqlDb.ExeDataSet(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["CssName"] != null)
                {
                    model.CssName = row["CssName"].ToString();
                }
                if (row["LabelName"] != null)
                {
                    model.LabelName = row["LabelName"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["Layer"] != null && row["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(row["Layer"].ToString());
                }
                if (row["ActionList"] != null)
                {
                    model.ActionList = row["ActionList"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        
        /// <summary>
        /// 获得所有列表
        /// </summary>
        public DataTable GetList(int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList from znModule order by SortID desc, ID asc");
            DataTable dt = znSqlDb.ExeDataSet(strSql.ToString()).Tables[0];
            if (dt == null) { return null; }
            DataTable allDT = dt.Clone();
            GetChilds(dt, allDT, parentID);
            return allDT;
        }

        /// <summary>
        /// 获取子记录
        /// </summary>
        public DataTable GetChildList(int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,CssName,LabelName,LinkUrl,SortID,ParentID,Path,Layer,ActionList from znModule");
            strSql.Append(" where ParentID=@ParentID order by SortID desc, ID asc");
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentID", SqlDbType.Int,4)
            };
            parameters[0].Value = parentID;

            DataSet ds = znSqlDb.ExeDataSet(strSql.ToString(), parameters);
            return ds.Tables[0];
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
                row["CssName"] = dr[i]["CssName"].ToString();
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

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parentID)
        {
            //查找父节点信息
            ZS.Model.znModule model = GetModel(conn, trans, parentID);
            if (model != null)
            {
                //查找子节点
                string sql = string.Format("select ID from znModule where ParentID={0}", parentID);
                DataSet ds = znSqlDb.ExeDataSet(conn, trans, sql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["id"].ToString());
                    string path = model.Path + id + ",";
                    int layer = Convert.ToInt32(model.Layer) + 1;
                    znSqlDb.ExeNonQuery(conn, trans, "update znModule set Path='" + path + "', Layer=" + layer + " where ID=" + id); //带事务

                    //调用自身迭代
                    this.UpdateChilds(conn, trans, id); //带事务
                }
            }
        }

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        private bool IsContainNode(int ID, int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znModule");
            strSql.Append(" where Path like '%," + ID + ",%,' and ID=" + parentID);
            return znSqlDb.Exists(strSql.ToString());
        }

    }
}