using System;
using System.Web;
using System.IO;

namespace ZS.KIT
{
    public class znError
    {
        /// <summary>
        /// 日志内容
        /// </summary>
        public static void Error(Exception oEx)
        {
            string[] strErr = new string[] { HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserAgent, oEx.Message, oEx.StackTrace };
            new znError().Save(strErr);
        }

        /// <summary>
        /// 生成日志
        /// </summary>
        public void Save(string[] stcErr)
        {
            DateTime now = DateTime.Now;
            string path = "~/errors/month_" + now.ToString("yyyy_MM");
            if (!Directory.Exists(znFile.GetMapPath(path)))
            {
                Directory.CreateDirectory(znFile.GetMapPath(path));
            }
            string fileName = "err_" + now.ToString("yyyyMMdd") + ".txt";
            string filePath = path + "/" + fileName;
            StreamWriter writer = null;
            if (znFile.FileExists(filePath))
            {
                writer = File.AppendText(znFile.GetMapPath(filePath));
            }
            else
            {
                writer = File.CreateText(znFile.GetMapPath(filePath));
            }
            writer.WriteLine("\r\n========== {0} ==========", DateTime.Now.ToString("HH:mm:ss"));
            writer.WriteLine("URL: {0}", stcErr[0]);
            writer.WriteLine("UIP: {0}", stcErr[2]);
            writer.WriteLine("AGE: {0}", stcErr[3]);
            writer.WriteLine("MSG: {0}", stcErr[1]);
            writer.WriteLine("STC:\r\n{0}", stcErr[4]);
            writer.WriteLine("=====================");
            writer.Flush();
            writer.Close();
            string errorFile = "~/error.html";
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            if (File.Exists(errorFile))
            {
                response.TransmitFile(errorFile);
            }
            else
            {
                response.Write("网站发生错误，请稍后访问！");
            }
            response.End();
        }
    }
}
