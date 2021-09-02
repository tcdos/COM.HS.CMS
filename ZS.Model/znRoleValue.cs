using System;

namespace ZS.Model
{
    /// <summary>
    /// znRoleValue:实体类()
    /// </summary>
    [Serializable]
    public partial class znRoleValue
    {
        public znRoleValue()
        { }
        #region Model
        private int _id;
        private int _roleid;
        private int _moduleid;
        private string _actionlist;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 模块ID
        /// </summary>
        public int ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
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
