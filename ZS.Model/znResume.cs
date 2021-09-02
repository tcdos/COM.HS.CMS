using System;


namespace ZS.Model
{
    /// <summary>
    /// znResume:实体类()
    /// </summary>
    [Serializable]
    public partial class znResume
    {
        public znResume()
        { }

        #region Model
        private int _id;
        private int _positionid;
        private string _author;
        private string _sex;
        private string _tel;
        private string _email;
        private string _resume;
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
        /// 职位ID
        /// </summary>
        public int PositionID
        {
            set { _positionid = value; }
            get { return _positionid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 简历
        /// </summary>
        public string Resume
        {
            set { _resume = value; }
            get { return _resume; }
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
