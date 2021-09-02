using System;

namespace ZS.Model
{
    /// <summary>
    /// znLink:实体类()
    /// </summary>
    [Serializable]
    public partial class znLink
    {
        public znLink()
        { }

        #region Model
        private int _id;
        private string _title;
        private int _categoryid;
        private string _linkurl;
        private string _logourl;
        private string _linknote;
        private int _sortid;
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
        /// 名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
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
        /// Logo
        /// </summary>
        public string LogoUrl
        {
            set { _logourl = value; }
            get { return _logourl; }
        }
        /// <summary>
        /// 介绍
        /// </summary>
        public string LinkNote
        {
            set { _linknote = value; }
            get { return _linknote; }
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
