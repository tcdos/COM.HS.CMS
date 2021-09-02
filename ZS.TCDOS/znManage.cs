using System;
using System.Data;
using ZS.KIT;

namespace ZS.TCDOS
{
    public class znManage : znTech
    {
        /// <summary>
        /// 委托加载
        /// </summary>
        public znManage()
        {
            this.Load += new EventHandler(manage_load);
        }

        /// <summary>
        /// 管理员是否登录
        /// </summary>
        private void manage_load(object sender, EventArgs e)
        {
            if (!IsUserLogin())
            {
                Response.Redirect("/cms/login.aspx");
                Response.End();
            }
        }

        /// <summary>
        /// 检测管理员是否登录
        /// </summary>
        public bool IsUserLogin()
        {
            if (Session["UserID"] == null || Session["UserName"] == null || Session["UserPwd"] == null || Session["UserPurview"] == null)
            {
                return false;
            }
            else
            {
                string userName = Session["UserName"].ToString();
                string userPwd = Session["UserPwd"].ToString();
                ZS.BLL.znUser bll = new ZS.BLL.znUser();
                ZS.Model.znUser model = bll.GetModel(userName, userPwd);
                if (model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public DataTable GetUserInfor()
        {
            if (IsUserLogin())
            {
                ZS.BLL.znUser bll = new BLL.znUser();
                DataTable dt;
                int isCache = znConvert.ObjToInt(znConfig.GetConfigInt("isCache"), 0);
                //不开启缓存机制
                if (isCache == 0)
                {
                    if (znConvert.ObjToInt(Session["UserPurview"], 0) == 0) 
                    {
                        //超级用户：不检测权限
                        dt = bll.GetUserInfor(znConvert.ObjToInt(Session["UserID"], 0), Session["UserName"].ToString(), Session["UserPwd"].ToString());
                    }
                    else
                    {
                        //系统用户：读取对应的角色权限表
                        dt = bll.GetUserInfor(znConvert.ObjToInt(Session["UserID"], 0), Session["UserName"].ToString(), Session["UserPwd"].ToString(), znConvert.ObjToInt(Session["UserPurview"], 0));
                    }
                }
                //开启缓存机制
                else
                {
                    if (znConvert.ObjToInt(Session["UserPurview"], 0) == 0)
                    {
                        //超级用户：不检测权限
                        dt = bll.GetUserInforByCache(znConvert.ObjToInt(Session["UserID"], 0), Session["UserName"].ToString(), Session["UserPwd"].ToString());
                    }
                    else
                    {
                        //系统用户：读取对应的角色权限表
                        dt = bll.GetUserInforByCache(znConvert.ObjToInt(Session["UserID"], 0), Session["UserName"].ToString(), Session["UserPwd"].ToString(), znConvert.ObjToInt(Session["UserPurview"], 0));
                    }
                }
                if (dt != null)
                {
                    return dt;
                }
            }
            return null;
        }

        /// <summary>
        /// 检测操作权限
        /// </summary>
        public void ChkUserLevel(string labelName, string action)
        {
            if (IsUserLogin())
            {
                if (znConvert.ObjToInt(Session["UserPurview"], 0) > 0)
                {
                    //系统用户：检测角色权限表
                    DataRow[] dr = GetUserInfor().Select("LabelName='" + labelName + "' and ActionList like '%" + action + "%'");
                    if (dr.Length <= 0)
                    {
                        znUtils.Redirect("您没有该功能模块的管理权限，请勿随意提交数据！");
                    }
                }
            }
        }

        /// <summary>
        /// 写入管理日志
        /// </summary>
        public void AddLog(string userName, string log)
        {
            ZS.BLL.znLog bll = new BLL.znLog();
            bll.Add(userName, log);
        }

        /// <summary>
        /// 登录用户常用操作
        /// </summary>
        public string GetUserPannel(int userID, string userName)
        {
            string strUser = "<span class='user'><b>" + userName + "</b></span><span class='pwd'><a href='system/password.aspx' target='conframe' title='修改密码'>修改密码</a></span><span class='exit'><a href='login.aspx?action=exit&userID=" + userID.ToString() + "' title='注销登录'>注销登录</a></span><span class='tech'><a href='" + znTech.systemUrl + "' target='_blank' title='技术支持-天草工坊'>技术支持</a></span>";
            return strUser;
        }

        /// <summary>
        /// 获取登录用户[一级模块]
        /// </summary>
        public string GetMoudule(int userID, string userName, int userPurview)
        {
            string strModule = string.Empty;

            ZS.BLL.znUser bll = new ZS.BLL.znUser();
            DataTable dt;
            int isCache = znConvert.ObjToInt(znConfig.GetConfigInt("isCache"), 0);
            if (isCache == 0)
            {
                dt = bll.GetUserModule(userID, userName, userPurview, 1);
            }
            else
            {
                dt = bll.GetUserModuleByCache(userID, userName, userPurview, 1);
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string linkUrl = string.IsNullOrEmpty(dr["LinkUrl"].ToString()) ? "javascript:void(0)" : dr["LinkUrl"].ToString();
                    strModule += "<li><a href='" + linkUrl + "'><i class='" + dr["CssName"].ToString() + "'></i><span>" + dr["Title"].ToString() + "</span></a></li>";
                }
            }
            return strModule;
        }

        /// <summary>
        /// 获取登录用户的所有子模块
        /// </summary>
        public string GetModuleList(int userID, string userName, int userPurview)
        {
            string strModule = string.Empty;
            ZS.BLL.znUser bll = new ZS.BLL.znUser();

            DataTable dt;
            int isCache = znConvert.ObjToInt(znConfig.GetConfigInt("isCache"), 0);
            if (isCache == 0)
            {
                dt = bll.GetUserModule(userID, userName, userPurview, 1);
            }
            else
            {
                dt = bll.GetUserModuleByCache(userID, userName, userPurview, 1);
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strModule += GetModuleListByParentID(userID, userName, userPurview, Convert.ToInt32(dr["ID"]));
                }
            }
            return strModule;

        }

        /// <summary>
        /// 获取子模块
        /// </summary>
        public string GetModuleListByParentID(int userID, string userName, int userPurview, int parentID)
        {
            string strModule = string.Empty;
            strModule += "<div class='zs-module-item module-tabs-item'>";
            strModule += "<h2 class='zs-module-title'></h2>";
            strModule += "<ul class='zs-nav'>";
            string span = "<span style=\"display:inline-block;width:{0}px;\"></span>";

            ZS.BLL.znUser bll = new ZS.BLL.znUser();
            DataTable dt;
            int isCache = znConvert.ObjToInt(znConfig.GetConfigInt("isCache"), 0);
            if (isCache == 0)
            {
                dt = bll.GetUserModuleList(userID, userName, userPurview, parentID);
            }
            else
            {
                dt = bll.GetUserModuleListByCache(userID, userName, userPurview, parentID);
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string linkUrl = string.IsNullOrEmpty(dr["LinkUrl"].ToString()) ? "javascript:void(0)" : dr["LinkUrl"].ToString();
                    string spanList = znConvert.ObjToInt(dr["Layer"], 0) > 2 ? string.Format(span, (znConvert.ObjToInt(dr["Layer"], 0) - 2) * 20) : string.Empty; //缩进
                    string icon = znConvert.ObjToInt(dr["Layer"], 0) == 2 ? "<i class=\"icon icon-group\"></i>" : "<i class=\"icon icon-item\"></i>"; //图标
                    string group= znConvert.ObjToInt(dr["Layer"], 0) == 2 ? "group" : string.Empty; //JS接口
                    strModule += "<li class='" + group + "'><a href='" + linkUrl + "' target='conframe'>" + spanList + icon + "<span>" + dr["Title"].ToString() + "</span></a></li>";
                }
            }
            strModule += "</ul>";
            strModule += "</div>";
            return strModule;
        }

    }
}
