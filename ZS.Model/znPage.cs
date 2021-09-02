using System;

namespace ZS.Model
{
    /// <summary>
    /// znPage:实体类()
    /// </summary>
    [Serializable]
    public partial class znPage
    {
        public znPage()
        { }

        #region Model
        private int _id;
        private int _categoryid;
        private string _title;
        private string _content;
        private int _sortid;
        private string _linkurl;
        private int _isurl;
        private string _username;
        private string _posttime;
        private int _ischeck;
        /// <summary>
        /// 编号ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 外链地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 是否外链
        /// </summary>
        public int isUrl
        {
            set { _isurl = value; }
            get { return _isurl; }
        }
        /// <summary>
        /// 发布者
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string PostTime
        {
            set { _posttime = value; }
            get { return _posttime; }
        }
        /// <summary>
        /// 审核
        /// </summary>
        public int isCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        #endregion Model

    }
}
