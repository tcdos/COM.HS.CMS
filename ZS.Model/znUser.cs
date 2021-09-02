using System;

namespace ZS.Model
{
    /// <summary>
    /// znUser:实体类()
    /// </summary>
    [Serializable]
    public partial class znUser
    {
        public znUser()
        { }

        #region Model
        private int _id;
        private string _username;
        private string _userpwd;
        private int _roleid;
        private int _purview;
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
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public int Purview
        {
            set { _purview = value; }
            get { return _purview; }
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
