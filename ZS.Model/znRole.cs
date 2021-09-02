using System;
namespace ZS.Model
{
    /// <summary>
    /// znRole:实体类()
    /// </summary>
    [Serializable]
    public partial class znRole
    {
        public znRole()
        { }
        #region Model
        private int _id;
        private string _rolename;
        private int _rolepurview;
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
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        #endregion Model

    }
}

