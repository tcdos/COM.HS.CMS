using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.KIT
{
    public class znDict
    {
        /// <summary>
        /// 获取操作权限
        /// </summary>
        public static Dictionary<string, string> ActionList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("View", "查看");
            dic.Add("Add", "添加");
            dic.Add("Edit", "修改");
            dic.Add("Delete", "删除");
            dic.Add("Reply", "回复");
            return dic;
        }

        /// <summary>
        /// 获取操作权限
        /// </summary>
        public static Dictionary<string, string> FileExtList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("txt", "文本文档");
            dic.Add("gif", "图片");
            dic.Add("jpg", "图片");
            dic.Add("jpeg", "图片");
            dic.Add("png", "图片");
            dic.Add("bmp", "图片");
            dic.Add("rar", "压缩文件");
            dic.Add("zip", "压缩文件");
            dic.Add("doc", "WORD文档");
            dic.Add("xls", "EXCEL表格");
            dic.Add("ppt", "PPT演示文档");
            dic.Add("pdf", "PDF文档");
            dic.Add("docx", "WORD文档");
            dic.Add("xlsx", "EXCEL表格");
            dic.Add("pptx", "PPT演示文档");
            return dic;
        }

    }
}
