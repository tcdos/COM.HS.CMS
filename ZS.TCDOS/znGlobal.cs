using System;
using System.Web.Routing;

namespace ZS.TCDOS
{
    public class znGlobal : System.Web.HttpApplication
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public znGlobal()
        {
        }

        /// <summary>
        /// 程序运行时触发
        /// </summary>
        protected void Application_Start(Object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Session生成时触发
        /// </summary>
        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 每次请求时触发
        /// </summary>
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 服务器停止时触发
        /// </summary>
        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 安全模块建立起当前用户的有效的身份时触发
        /// </summary>
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 程序错误时触发
        /// </summary>
        protected void Application_Error(Object sender, EventArgs e)
        {
            base.Response.Clear();
            ZS.KIT.znError.Error(base.Server.GetLastError().GetBaseException());
            base.Server.ClearError();
        }

        /// <summary>
        /// Session失效时触发
        /// </summary>
        protected void Session_End(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 程序结束时触发
        /// </summary>
        protected void Application_End(Object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 路由规则
        /// </summary>
        protected void RegisterRoutes(RouteCollection routes)
        {
            //for ZS.CMS.Web.MSSQL
            //首页
            routes.MapPageRoute("index", "index", "~/index.aspx", false);
            //概况
            routes.MapPageRoute("intro", "intro/{id}", "~/intro.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //联系
            routes.MapPageRoute("contact", "contact/{id}", "~/contact.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });            
            //留言
            routes.MapPageRoute("feedback", "feedback", "~/feedback.aspx", false);            
            //新闻
            routes.MapPageRoute("news", "news", "~/news.aspx", false);
            routes.MapPageRoute("news_list", "news/{page}", "~/news.aspx", false, new RouteValueDictionary { { "page", @"\d+" } });
            routes.MapPageRoute("news_category_list", "news/list/{categoryID}/{page}", "~/news.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("news_detail", "news/detail/{id}", "~/news_detail.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //产品
            routes.MapPageRoute("product", "product", "~/product.aspx", false);
            routes.MapPageRoute("product_tree", "product/{id}", "~/product.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            routes.MapPageRoute("product_list", "product/{page}", "~/product.aspx", false, new RouteValueDictionary { { "page", @"\d+" } });
            routes.MapPageRoute("product_category_list", "product/list/{categoryID}/{page}", "~/product.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("product_detail", "product/detail/{id}", "~/product_detail.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //案例
            routes.MapPageRoute("case", "case", "~/case.aspx", false);
            routes.MapPageRoute("case_list", "case/{page}", "~/case.aspx", false, new RouteValueDictionary { { "page", @"\d+" } });
            routes.MapPageRoute("case_category_list", "case/list/{categoryID}/{page}", "~/case.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("case_detail", "case/detail/{id}", "~/case_detail.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //下载
            routes.MapPageRoute("download", "download", "~/download.aspx", false);
            routes.MapPageRoute("download_list", "download/list/{categoryID}/{page}", "~/download.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("download_category_list", "download/list/{categoryID}/{page}", "~/download.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("downfile", "downfile/{id}", "~/downfile.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //人力
            routes.MapPageRoute("hr", "hr", "~/hr.aspx", false);
            routes.MapPageRoute("hr_list", "hr/{page}", "~/hr.aspx", false, new RouteValueDictionary { { "page", @"\d+" } });
            routes.MapPageRoute("hr_category_list", "hr/list/{categoryID}", "~/hr.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" } });
            routes.MapPageRoute("hr_apply", "apply/{id}", "~/apply.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            //方案
            routes.MapPageRoute("solution", "solution", "~/solution.aspx", false);
            routes.MapPageRoute("solution_tree", "solution/{id}", "~/solution.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });
            routes.MapPageRoute("solution_list", "solution/{page}", "~/solution.aspx", false, new RouteValueDictionary { { "page", @"\d+" } });
            routes.MapPageRoute("solution_category_list", "solution/list/{categoryID}/{page}", "~/solution.aspx", false, new RouteValueDictionary { { "categoryID", @"\d+" }, { "page", @"\d+" } });
            routes.MapPageRoute("solution_detail", "solution/detail/{id}", "~/solution_detail.aspx", false, new RouteValueDictionary { { "id", @"\d+" } });

        }

    }
}
