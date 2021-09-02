using System;
namespace ZS.Model
{
    /// <summary>
    /// znSolution:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class znSolution
    {
        public znSolution()
        { }
        #region Model
        private int _id;
        private int _categoryid;
        private string _title;
        private string _shorttitle;
        private int _sortid;
        private int _hits;
        private string _idxpic;
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
        /// ID
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
        /// 简短名称
        /// </summary>
        public string ShortTitle
        {
            set { _shorttitle = value; }
            get { return _shorttitle; }
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
        /// 浏览次数
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 首页图标
        /// </summary>
        public string IdxPic
        {
            set { _idxpic = value; }
            get { return _idxpic; }
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
        /// 链接地址
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

