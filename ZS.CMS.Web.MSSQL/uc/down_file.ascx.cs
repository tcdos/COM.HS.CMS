using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using ZS.KIT;

public partial class uc_down_file : System.Web.UI.UserControl
{
    private int _id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        this._id = znConvert.ObjToInt(Page.RouteData.Values["id"], 0);
        if (this._id == 0)
        {
            Response.Redirect("~/tips.aspx?msg=参数不合法，请勿随意提交数据！", true);
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            ZS.BLL.znDownload bll = new ZS.BLL.znDownload();
            if (bll.Exists(this._id, true))
            {
                ZS.Model.znDownload model = bll.GetModel(this._id);
                if (model == null)
                {
                    Response.Redirect("~/tips.aspx?msg=该记录不存在，请勿随意提交数据！", true);
                    Response.End();
                }
                else
                {
                    string fileUrl = model.FileUrl;
                    string downUrl = string.Empty;
                    model.Hits = model.Hits + 1;
                    bll.Update(model);
                    if (fileUrl.IndexOf("$") > 0)
                    {
                        downUrl = fileUrl.Split('$')[0];
                    }
                    else
                    {
                        downUrl = fileUrl;
                    }
                    DownloadFile(downUrl);
                }
            }
            else
            {
                Response.Redirect("~/tips.aspx?msg=该记录不存在，请勿随意提交数据！", true);
                Response.End();
            }
        }
    }

    /// <summary>
    /// 文件下载
    /// </summary>
    protected void DownloadFile(string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
        {
            Response.Redirect("~/tips.aspx?msg=下载时出现错误。该文件不存在，请返回！", true);
            Response.End();
        }
        else
        {
            //下载配置
            bool isDown = false;
            string allowDownUrl = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(znUtils.GetXmlMapPath("configPath"));
                XmlNode root = xmlDoc.SelectSingleNode("//site_config");
                isDown = Convert.ToBoolean((root.SelectSingleNode("isDown")).InnerText);
                allowDownUrl = (root.SelectSingleNode("allowDownUrl")).InnerText;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/tips.aspx?msg=下载时出现错误。文件下载配置出错，请返回！", true);
                Response.End();
            }
            if (isDown == false)
            {
                Response.Redirect(fileUrl);
                return;
            }
            else
            {
                string urlReferrer = string.Empty;
                if (Request.UrlReferrer != null)
                {
                    urlReferrer = Request.UrlReferrer.ToString().ToLower();
                }
                string[] allowUrl = allowDownUrl.ToLower().Split(new char[] { ',' });
                foreach (string url in allowUrl)
                {
                    if (urlReferrer.IndexOf(url.ToLower()) > 0)
                    {
                        ResponseFile(fileUrl);
                        return;
                    }
                }
                Response.Redirect("~/tips.aspx?msg=该文件禁止直接下载与盗链，请勿随意提交数据！", true);
                Response.End();
            }
        }
    }

    /// <summary>
    /// 文件输出
    /// </summary>
    protected void ResponseFile(string fileUrl)
    {
        System.IO.Stream iStream = null;
        byte[] buffer = new Byte[10000];
        int length;
        long dataToRead;
        string filename = System.IO.Path.GetFileName(fileUrl);
        try
        {
            iStream = new System.IO.FileStream(znFile.GetMapPath(fileUrl), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            dataToRead = iStream.Length;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
            while (dataToRead > 0)
            {
                if (Response.IsClientConnected)
                {
                    length = iStream.Read(buffer, 0, 10000);
                    Response.OutputStream.Write(buffer, 0, length);
                    Response.Flush();
                    buffer = new Byte[10000];
                    dataToRead = dataToRead - length;
                }
                else
                {
                    dataToRead = -1;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/tips.aspx?msg=下载时出现错误。该文件可能已经被删除！", true);
            Response.End();
        }
        finally
        {
            if (iStream != null)
            {
                iStream.Close();
            }
        }
    }


}