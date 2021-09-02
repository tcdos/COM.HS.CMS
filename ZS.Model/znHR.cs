using System;
namespace ZS.Model
{
    /// <summary>
    /// znHR:实体类()
    /// </summary>
    [Serializable]
    public partial class znHR
    {
        public znHR()
        { }
        #region Model
        private int _id;
        private int _categoryid;
        private string _title;
        private int _limitnum;
        private string _address;
        private string _salary;
        private string _email;
        private string _infor;
        private string _request;
        private string _startdate;
        private string _enddate;
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
        /// 名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 招聘数量
        /// </summary>
        public int LimitNum
        {
            set { _limitnum = value; }
            get { return _limitnum; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 薪酬
        /// </summary>
        public string Salary
        {
            set { _salary = value; }
            get { return _salary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Infor
        {
            set { _infor = value; }
            get { return _infor; }
        }
        /// <summary>
        /// 要求
        /// </summary>
        public string Request
        {
            set { _request = value; }
            get { return _request; }
        }
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostTime
        {
            set { _posttime = value; }
            get { return _posttime; }
        }
        #endregion Model

    }
}

