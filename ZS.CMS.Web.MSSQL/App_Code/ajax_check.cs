using System.Web;
using System.Web.SessionState;
using ZS.KIT;

public class ajax_check : IHttpHandler, IRequiresSessionState
{

    /// <summary>
    /// 数据验证
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        string action = znRequest.GetQueryString("action");
        switch (action)
        {
            //检测用户名是否重复
            case "checkUserName":
                CheckUserName(context);
                break;
            //检测角色名称是否重复
            case "checkRoleName":
                CheckRoleName(context);
                break;
        }
    }

    /// <summary>
    /// 验证管理员用户名是否重复
    /// </summary>
    /// <param name="context"></param>
    private void CheckUserName(HttpContext context)
    {
        string userName = znRequest.GetString("param");
        if (string.IsNullOrEmpty(userName))
        {
            context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
            return;
        }
        if (!znSafe.IsSafeStr(userName))
        {
            context.Response.Write("{ \"info\":\"输入用户名含有非法字符\", \"status\":\"n\" }");
            return;
        }
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        if (bll.Exists(userName))
        {
            context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
        return;
    }

    /// <summary>
    /// 检测角色名称是否重复
    /// </summary>
    /// <param name="context"></param>
    private void CheckRoleName(HttpContext context)
    {
        string roleName = znRequest.GetString("param");
        if (string.IsNullOrEmpty(roleName))
        {
            context.Response.Write("{ \"info\":\"请输入名称！\", \"status\":\"n\" }");
            return;
        }
        if (!znSafe.IsSafeStr(roleName))
        {
            context.Response.Write("{ \"info\":\"输入的名称含有非法字符！\", \"status\":\"n\" }");
            return;
        }
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        if (bll.Exists(roleName))
        {
            context.Response.Write("{ \"info\":\"输入的名称已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"输入的名称可以使用！\", \"status\":\"y\" }");
        return;
    }

    /// <summary>
    /// 线程控制
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}