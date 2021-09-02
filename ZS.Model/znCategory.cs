using System;

namespace ZS.Model
{
    /// <summary>
    /// znCategory:实体类()
    /// </summary>
    [Serializable]
    public partial class znCategory
    {
        public znCategory()
        { }

        #region Model
        private int _id;
        private int _channelid;
        private string _title;
        private int _parentid;
        private string _path;
        private int _layer;
        private int _sortid;
        private string _linkurl;
        private int _isurl;
        /// <summary>
        /// 编号ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
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
        #endregion Model

    }
}
