using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Xml;

namespace ZS.KIT
{
    public class znUpload
    {
        //上传配置
        private string _allowExt = string.Empty;
        private string _maxUploadSize = string.Empty;

        /// <summary>
        /// 文件上传：返回格式// {"status":1,"msg":"提示文本","filePath":"attach/2016/04/08/201604081455.jpg","fileSize":"100KB","fileExt":"jpg"}
        /// </summary>
        public string SaveFile(HttpPostedFile postedFile, bool isThumbnail, int w, int h, string mode, bool delOriginalImage, bool backThumbnailUrl)
        {
            //上传配置
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(znUtils.GetXmlMapPath("configPath"));
                XmlNode root = xmlDoc.SelectSingleNode("//site_config");
                this._allowExt = (root.SelectSingleNode("allowExt")).InnerText; //上传类型白名单
                this._maxUploadSize = (root.SelectSingleNode("maxUploadSize")).InnerText; //大小限制
            }
            catch (Exception ex)
            {
                return "{\"status\":0, \"msg\":\"上传配置文件错误!\", \"fielPath\":\"\", \"fileSize\":\"\", \"fileExt\":\"\"}";
            }

            //选择文件
            if (postedFile.ContentLength <= 0)
            {
                return "{\"status\":0, \"msg\":\"请选择上传文件&文件内容为空!\", \"fielPath\":\"\", \"fileSize\":\"\", \"fileExt\":\"\"}";
            }

            //大小检测
            string fileSize = znFile.GetFileSize(postedFile.ContentLength);
            if (postedFile.ContentLength > znConvert.StrToInt(this._maxUploadSize, 0))
            {
                return "{\"status\":0, \"msg\":\"上传失败：上传文件大小超出系统限制!\", \"fielPath\":\"\", \"fileSize\":\"\", \"fileExt\":\"\"}";
            }

            //格式检测
            string fileExt = znFile.GetFileExt(postedFile.FileName);
            if (!CheckFileExt(fileExt))
            {
                return "{\"status\":0, \"msg\":\"上传失败：上传文件格式非法!\", \"fielPath\":\"\", \"fileSize\":\"\", \"fileExt\":\"\"}";
            }
            
            //上传
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + znUtils.GetRamNum(4); //文件名：时间+随机数
            string fileFolder = "/attach/" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + "/"; //文件夹路径
            if (!Directory.Exists(znFile.GetMapPath(fileFolder))) //文件夹路径是否存在
            {
                Directory.CreateDirectory(znFile.GetMapPath(fileFolder));
            }
            string filePath = znFile.GetMapPath(fileFolder) + fileName + "." + fileExt; //完整的文件路径
            postedFile.SaveAs(filePath);
            
            string originalFilePath = fileFolder + fileName + "." + fileExt; //上传原始的文件路径
            string thumbnailPath = fileFolder + fileName + "_thumb" + "." + fileExt; //生成缩略图的文件路径

            //生成缩略图：图片类型
            if (IsImage(fileExt) && Convert.ToBoolean(isThumbnail))
            {
               znThumbnail.MakeThumbnail(znFile.GetMapPath(originalFilePath), znFile.GetMapPath(thumbnailPath), w, h, mode);
            }

            //是否删除原始图片：图片类型+缩略图已经生成
            if (IsImage(fileExt) && Convert.ToBoolean(delOriginalImage) && znFile.FileExists(thumbnailPath)) 
            {
                znFile.DeleteFile(originalFilePath);
            }

            //返回路径
            if (IsImage(fileExt) && Convert.ToBoolean(backThumbnailUrl) && znFile.FileExists(thumbnailPath))
            {
                return "{\"status\":1, \"msg\":\"上传成功!\", \"filePath\":\"" + thumbnailPath + "\", \"fileSize\":\"" + fileSize + "\", \"fileExt\":\"" + fileExt + "\"}"; //图片类型+要求返回缩略图路径+缩略图已经生成
            }
            else
            {
                return "{\"status\":1, \"msg\":\"上传成功!\", \"filePath\":\"" + originalFilePath + "\", \"fileSize\":\"" + fileSize + "\", \"fileExt\":\"" + fileExt + "\"}"; //非图片类型
            }
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string fileExt)
        {
            //检查危险文件
            string[] excExt = { "asp", "aspx", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = this._allowExt.Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检测是否为图片类型
        /// </summary>
        private bool IsImage(string fileExt)
        {
            ArrayList extList = new ArrayList();
            extList.Add("bmp");
            extList.Add("jpeg");
            extList.Add("jpg");
            extList.Add("gif");
            extList.Add("png");
            if (extList.Contains(fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
