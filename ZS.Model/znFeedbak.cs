using System;

namespace ZS.Model
{
    /// <summary>
    /// znFeedback:实体类()
    /// </summary>
    [Serializable]
    public partial class znFeedback
    {
        public znFeedback()
        { }

        private int _id;
        private int _memberid;
        private string _author;
        private string _tel;
        private string _email;
        private string _category;
        private string _content;
        private string _postip;
        private string _posttime;
        private string _replycontent;
        private string _replyusername;
        private string _replytime;
        private int _ischeck = 0;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        public int MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
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
        /// 类型
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public string PostIP
        {
            set { _postip = value; }
            get { return _postip; }
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
        /// 回复内容
        /// </summary>
        public string ReplyContent
        {
            set { _replycontent = value; }
            get { return _replycontent; }
        }
        /// <summary>
        /// 回复者
        /// </summary>
        public string ReplyUserName
        {
            set { _replyusername = value; }
            get { return _replyusername; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        public string ReplyTime
        {
            set { _replytime = value; }
            get { return _replytime; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public int isCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }

    }
}
