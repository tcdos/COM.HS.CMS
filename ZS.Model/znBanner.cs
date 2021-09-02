using System;
namespace ZS.Model
{
    /// <summary>
    /// znBanner:实体类()
    /// </summary>
    [Serializable]
    public partial class znBanner
    {
        public znBanner()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _smallpic;
        private int _sortid;
        private int _ischeck;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallPic
        {
            set { _smallpic = value; }
            get { return _smallpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        #endregion Model

    }
}

