using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using ZS.DB;
using ZS.KIT;

namespace ZS.DAL
{
    /// <summary>
    /// 数据访问类
    /// </summary>
    public partial class znFeedback
    {
        public znFeedback()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from znFeedback");
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
        public bool Add(ZS.Model.znFeedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into znFeedback(");
            strSql.Append("MemberID,Author,Tel,Email,Category,Content,PostIP,PostTime,ReplyContent,ReplyUserName,ReplyTime,isCheck)");
            strSql.Append(" values (");
            strSql.Append("@MemberID,@Author,@Tel,@Email,@Category,@Content,@PostIP,@PostTime,@ReplyContent,@ReplyUserName,@ReplyTime,@isCheck)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Category", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReplyUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Category;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.PostIP;
            parameters[7].Value = model.PostTime;
            parameters[8].Value = model.ReplyContent;
            parameters[9].Value = model.ReplyUserName;
            parameters[10].Value = model.ReplyTime;
            parameters[11].Value = model.isCheck;

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
                //发送邮件
                if (!string.IsNullOrEmpty(model.Email))
                {
                    postMail(model, 0);
                }
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
        public bool Update(ZS.Model.znFeedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update znFeedback set ");
            strSql.Append("MemberID=@MemberID,");
            strSql.Append("Author=@Author,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Email=@Email,");
            strSql.Append("Category=@Category,");
            strSql.Append("Content=@Content,");
            strSql.Append("PostIP=@PostIP,");
            strSql.Append("PostTime=@PostTime,");
            strSql.Append("ReplyContent=@ReplyContent,");
            strSql.Append("ReplyUserName=@ReplyUserName,");
            strSql.Append("ReplyTime=@ReplyTime,");
            strSql.Append("isCheck=@isCheck");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Category", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReplyUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyTime", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheck", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Category;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.PostIP;
            parameters[7].Value = model.PostTime;
            parameters[8].Value = model.ReplyContent;
            parameters[9].Value = model.ReplyUserName;
            parameters[10].Value = model.ReplyTime;
            parameters[11].Value = model.isCheck;
            parameters[12].Value = model.ID;

            //DBNull
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }

            //提交数据
            int rows = znSqlDb.ExeNonQuery(strSql.ToString(), parameters);
            //发送邮件
            if (!string.IsNullOrEmpty(model.Email))
            {
                postMail(model, 1);
            }
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
        /// 发送邮件
        /// </summary>
        private bool postMail(ZS.Model.znFeedback model, int mailType)
        {
            string comName = string.Empty;
            string mailContent = string.Empty;
            string postMail = string.Empty;
            string mailUserName = string.Empty;
            string mailUserPwd = string.Empty;
            string smtpHost = string.Empty;
            int smtpPort = 25;
            //格式化邮件内容
            if (mailType == 1)//回复内容
            {
                mailContent += "<p style='color:#888'>您收到此邮件，是因为您在我们官方网站在线提交过反馈信息；如果此操作非本人行为，请忽略此邮件。</p>";
                mailContent += "<p>" + znUtils.ToHtml(model.ReplyContent.ToString()) + "</p>";
            }
            else//留言内容
            {
                mailContent += "<p><b>留言类型：</b>" + znUtils.ToHtml(model.Category.ToString()) + "</p>";
                mailContent += "<p><b>留言内容：</b>" + znUtils.ToHtml(model.Content.ToString()) + "</p>";
                mailContent += "<p><b>联系人：</b>" + znUtils.ToHtml(model.Author.ToString()) + "</p>";
                mailContent += "<p><b>联系电话：</b>" + znUtils.ToHtml(model.Tel.ToString()) + "</p>";
                mailContent += "<p><b>电子邮箱：</b>" + znUtils.ToHtml(model.Email.ToString()) + "</p>";
            }
            
            //发送邮件
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(znUtils.GetXmlMapPath("configPath"));
                XmlNode root = xmlDoc.SelectSingleNode("//site_config");
                comName = (root.SelectSingleNode("comName")).InnerText;
                postMail = (root.SelectSingleNode("postMail")).InnerText;
                mailUserName = (root.SelectSingleNode("mailUserName")).InnerText;
                mailUserPwd = (root.SelectSingleNode("mailUserPwd")).InnerText;
                smtpHost = (root.SelectSingleNode("smtpHost")).InnerText;
                smtpPort = Convert.ToInt32((root.SelectSingleNode("smtpPort")).InnerText);
                try
                {
                    znMail.sendMail(model.Email.ToString(), "来自" + comName + "官方网站的反馈信息[请勿回复此邮件]", mailContent, "", postMail, mailUserName, znSafe.Decrypt(mailUserPwd, "tcdosCOM"), smtpHost, smtpPort);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            catch (Exception ex)
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
            strSql.Append("update znFeedback set " + strValue);
            strSql.Append(" where id=" + id);
            znSqlDb.ExeNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from znFeedback ");
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
            strSql.Append("delete from znFeedback ");
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
        public ZS.Model.znFeedback GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,MemberID,Author,Tel,Email,Category,Content,PostIP,PostTime,ReplyContent,ReplyUserName,ReplyTime,isCheck from znFeedback ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            ZS.Model.znFeedback model = new ZS.Model.znFeedback();
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
        public ZS.Model.znFeedback DataRowToModel(DataRow row)
        {
            ZS.Model.znFeedback model = new ZS.Model.znFeedback();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MemberID"] != null && row["MemberID"].ToString() != "")
                {
                    model.MemberID = int.Parse(row["MemberID"].ToString());
                }
                if (row["Author"] != null)
                {
                    model.Author = row["Author"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Category"] != null)
                {
                    model.Category = row["Category"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["PostIP"] != null)
                {
                    model.PostIP = row["PostIP"].ToString();
                }
                if (row["PostTime"] != null)
                {
                    model.PostTime = row["PostTime"].ToString();
                }
                if (row["ReplyContent"] != null)
                {
                    model.ReplyContent = row["ReplyContent"].ToString();
                }
                if (row["ReplyUserName"] != null)
                {
                    model.ReplyUserName = row["ReplyUserName"].ToString();
                }
                if (row["ReplyTime"] != null)
                {
                    model.ReplyTime = row["ReplyTime"].ToString();
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
            strSql.Append("select ID,MemberID,Author,Tel,Email,Category,Content,PostIP,PostTime,ReplyContent,ReplyUserName,ReplyTime,isCheck ");
            strSql.Append(" from znFeedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return znSqlDb.ExeDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(string category, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            category = category.Trim().Replace("'", "");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MemberID,Author,Tel,Email,Category,Content,PostIP,PostTime,ReplyContent,ReplyUserName,ReplyTime,isCheck from znFeedback where ID>0");
            if (!string.IsNullOrEmpty(category))
            {
                strSql.Append(" and Category like '%" + category + "%'");
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
