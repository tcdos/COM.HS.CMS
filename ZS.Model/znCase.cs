using System;

namespace ZS.Model
{
    /// <summary>
    /// znArticle:实体类()
    /// </summary>
    [Serializable]
    public partial class znCase
    {
        public znCase()
        { }

        #region Model
        private int _id;
        private int _categoryid;
        private string _title;
        private string _source;
        private int _sortid;
        private int _hits;
        private string _smallpic;
        private string _summary;
        private string _content;
        private string _linkurl;
        private int _isurl;
        private int _istop;
        private int _iselite;
        private int _ischeck;
        private string _username;
        private string _posttime;
        /// <summary>
        /// 编号ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string SmallPic
        {
            set { _smallpic = value; }
            get { return _smallpic; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
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
        /// 固顶
        /// </summary>
        public int isTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        public int isElite
        {
            set { _iselite = value; }
            get { return _iselite; }
        }
        /// <summary>
        /// 审核
        /// </summary>
        public int isCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
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
        #endregion Model
    }
}
