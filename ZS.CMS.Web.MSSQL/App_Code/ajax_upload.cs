using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using ZS.KIT;
using ZS.TCDOS;
using LitJson;

public class ajax_upload : IHttpHandler, IRequiresSessionState
{

    /// <summary>
    /// 文件上传与文件浏览
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        //登录检测
        znManage manage = new znManage();

        //事件处理
        string action = znRequest.GetQueryString("action");
        switch (action)
        {
            case "FileUpload":
                FileUpload(context);
                break;
            case "FileManage":
                FileManage(context);
                break;
        }
    }

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="context"></param>
    private void FileUpload(HttpContext context)
    {
        //上传配置
        bool editorAuto = false;
        int editorMaxW = 0;
        string mode = "w";
        bool delOriginalImage = true;
        bool backThumbnailUrl = true;
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            xmlDoc.Load(znUtils.GetXmlMapPath("configPath"));
            XmlNode root = xmlDoc.SelectSingleNode("//site_config");
            editorAuto = znConvert.StrToBool((root.SelectSingleNode("editorAuto")).InnerText, false);
            editorMaxW = znConvert.StrToInt((root.SelectSingleNode("editorMaxW")).InnerText, 600);
        }
        catch (Exception ex)
        {
            showError(context, "{\"status\":0, \"msg\":\"上传失败：上传配置文件出错!\", \"fielPath\":\"\"}");
            return;
        }
        //文件上传
        HttpPostedFile imgFile = context.Request.Files["imgFile"];
        znUpload up = new znUpload();
        string data = up.SaveFile(imgFile, editorAuto, editorMaxW, 0, mode, delOriginalImage, backThumbnailUrl); 
        JsonData jd = JsonMapper.ToObject(data); //转成JSON
        string status = jd["status"].ToString(); //是否上传成功
        string msg = jd["msg"].ToString(); //提示文本
        if (status == "0")
        {
            showError(context, msg);
            return;
        }
        else
        {
            string filePath = jd["filePath"].ToString(); //文件路径
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = filePath;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(hash));
            context.Response.End();
        }
    }

    /// <summary>
    /// 文件管理
    /// </summary>
    /// <param name="context"></param>
    private void FileManage(HttpContext context)
    {
        //根目录路径，相对路径
        String rootPath = "/attach/";
        //根目录URL，可以指定绝对路径
        String rootUrl = "/attach/";
        //图片扩展名
        String fileTypes = "gif,jpg,jpeg,png,bmp";

        String currentPath = "";
        String currentUrl = "";
        String currentDirPath = "";
        String moveupDirPath = "";

        String dirPath = context.Server.MapPath(rootPath);
        String dirName = context.Request.QueryString["dir"];

        //根据path参数，设置各路径和URL
        String path = context.Request.QueryString["path"];
        path = String.IsNullOrEmpty(path) ? "" : path;
        if (path == "")
        {
            currentPath = dirPath;
            currentUrl = rootUrl;
            currentDirPath = "";
            moveupDirPath = "";
        }
        else
        {
            currentPath = dirPath + path;
            currentUrl = rootUrl + path;
            currentDirPath = path;
            moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
        }

        //排序形式，name or size or type
        String order = context.Request.QueryString["order"];
        order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

        //不允许使用..移动到上一级目录
        if (Regex.IsMatch(path, @"\.\."))
        {
            context.Response.Write("Access is not allowed.");
            context.Response.End();
        }
        //最后一个字符不是/
        if (path != "" && !path.EndsWith("/"))
        {
            context.Response.Write("Parameter is not valid.");
            context.Response.End();
        }
        //目录不存在或不是目录
        if (!Directory.Exists(currentPath))
        {
            context.Response.Write("Directory does not exist.");
            context.Response.End();
        }

        //遍历目录获取文件信息
        string[] dirList = Directory.GetDirectories(currentPath);
        string[] fileList = Directory.GetFiles(currentPath);

        switch (order)
        {
            case "size":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new SizeSorter());
                break;
            case "type":
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new TypeSorter());
                break;
            case "name":
            default:
                Array.Sort(dirList, new NameSorter());
                Array.Sort(fileList, new NameSorter());
                break;
        }

        Hashtable result = new Hashtable();
        result["moveup_dir_path"] = moveupDirPath;
        result["current_dir_path"] = currentDirPath;
        result["current_url"] = currentUrl;
        result["total_count"] = dirList.Length + fileList.Length;
        List<Hashtable> dirFileList = new List<Hashtable>();
        result["file_list"] = dirFileList;
        for (int i = 0; i < dirList.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(dirList[i]);
            Hashtable hash = new Hashtable();
            hash["is_dir"] = true;
            hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
            hash["filesize"] = 0;
            hash["is_photo"] = false;
            hash["filetype"] = "";
            hash["filename"] = dir.Name;
            hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }
        for (int i = 0; i < fileList.Length; i++)
        {
            FileInfo file = new FileInfo(fileList[i]);
            Hashtable hash = new Hashtable();
            hash["is_dir"] = false;
            hash["has_file"] = false;
            hash["filesize"] = file.Length;
            hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
            hash["filetype"] = file.Extension.Substring(1);
            hash["filename"] = file.Name;
            hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dirFileList.Add(hash);
        }
        context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(result));
        context.Response.End();
    }

    /// <summary>
    /// 排序
    /// </summary>
    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());
            return xInfo.FullName.CompareTo(yInfo.FullName);
        }
    }
    /// <summary>
    /// 排序
    /// </summary>
    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());
            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }
    /// <summary>
    /// 排序
    /// </summary>
    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());
            return xInfo.Extension.CompareTo(yInfo.Extension);
        }
    }

    /// <summary>
    /// 返回Error
    /// </summary>
    /// <param name="context"></param>
    /// <param name="errmsg"></param>
    private void showError(HttpContext context, string errmsg)
    {
        Hashtable hash = new Hashtable();
        hash["error"] = 1;
        hash["message"] = errmsg;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
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