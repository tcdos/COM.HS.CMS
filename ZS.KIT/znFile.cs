using System;
using System.Web;
using System.IO;

namespace ZS.KIT
{
    public class znFile
    {
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 检测文件是否存在
        /// </summary>
        public static bool FileExists(string filePath)
        {
            string fullpath = GetMapPath(filePath);
            if (File.Exists(fullpath))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除单个文件
        /// </summary>
        public static bool DeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            string fullpath = GetMapPath(filePath);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取文件大小[KB]
        /// </summary>
        public static int GetFileSize(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return 0;
            }
            string fullpath = GetMapPath(filePath);
            if (File.Exists(fullpath))
            {
                FileInfo fileInfo = new FileInfo(fullpath);
                return ((int)fileInfo.Length) / 1024;
            }
            return 0;
        }

        /// <summary>
        /// 返回文件名，不含路径
        /// </summary>
        public static string GetFileName(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf(@"/") + 1);
        }

        /// <summary>
        /// 获取文件扩展名，不含“.”
        /// </summary>
        public static string GetFileExt(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return "";
            }
            if (filePath.LastIndexOf(".") > 0)
            {
                return filePath.Substring(filePath.LastIndexOf(".") + 1);
            }
            return "";
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        public static string GetFileSize(long length)
        {
            string size = "";
            long K = 1024;
            long M = 1024 * 1024;
            if (length < 1000)
            {
                size = length.ToString() + "B";
            }
            else if (length < K * 1000)
            {
                size = ((float)Math.Round(((float)(length / (float)K)), 2)).ToString() + "KB";
            }
            else
            {
                size = ((float)Math.Round(((float)(length / (float)M)))).ToString() + "M";
            }
            return size;
        }
    }
}
