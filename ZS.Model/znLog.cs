using System;

namespace ZS.Model
{
    /// <summary>
    /// znLog:实体类()
    /// </summary>
    [Serializable]
    public partial class znLog
    {
        public znLog()
        { }

        #region Model
        private int _id;
        private string _username;
        private string _loginip;
        private string _logintime;
        private string _log;
        /// <summary>
        /// 编号ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string LoginIP
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public string LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 日志
        /// </summary>
        public string Log
        {
            set { _log = value; }
            get { return _log; }
        }
        #endregion Model

    }
}
