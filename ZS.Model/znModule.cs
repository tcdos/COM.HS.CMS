using System;
namespace ZS.Model
{
    /// <summary>
    /// znModule:实体类()
    /// </summary>
    [Serializable]
    public partial class znModule
    {
        public znModule()
        { }

        #region Model
        private int _id;
        private string _title;
        private string _cssname;
        private string _labelname;
        private string _linkurl;
        private int _sortid;
        private int _parentid;
        private string _path;
        private int _layer;
        private string _actionlist;
        /// <summary>
        /// 编号ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 样式接口
        /// </summary>
        public string CssName
        {
            set { _cssname = value; }
            get { return _cssname; }
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string LabelName
        {
            set { _labelname = value; }
            get { return _labelname; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
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
        /// 父ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 层级
        /// </summary>
        public int Layer
        {
            set { _layer = value; }
            get { return _layer; }
        }
        /// <summary>
        /// 操作
        /// </summary>
        public string ActionList
        {
            set { _actionlist = value; }
            get { return _actionlist; }
        }
        #endregion Model

    }
}

