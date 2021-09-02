using System;
using System.Collections.Generic;
using System.Data;
using ZS.KIT;

namespace ZS.BLL
{
    public partial class znUser
    {
        private readonly ZS.DAL.znUser dal = new ZS.DAL.znUser();
        public znUser()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            return dal.Exists(ID, isCheck);
        }

        /// <summary>
        /// 是否存在该列
        /// </summary>
        public bool Exists(string columnName)
        {
            return dal.Exists(columnName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znUser model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znUser GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znUser GetModel(string UserName, string UserPwd)
        {

            return dal.GetModel(UserName, UserPwd);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znUser> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znUser> DataTableToList(DataTable dt)
        {
            List<ZS.Model.znUser> modelList = new List<ZS.Model.znUser>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZS.Model.znUser model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取数据列表[分页]
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, sortFiled, out recordCount);
        }

        /// <summary>
        /// 获取[超级用户]信息
        /// </summary>
        public DataTable GetUserInfor(int userID, string userName, string userPwd)
        {
            return dal.GetUserInfor(userName, userPwd);
        }

        /// <summary>
        /// 从缓存中获取[超级用户]信息
        /// </summary>
        public DataTable GetUserInforByCache(int userID, string userName, string userPwd)
        {
            string CacheKey = "znUserInfor-" + userID;
            object UserInfor = znCache.GetCache(CacheKey);
            if (UserInfor == null)
            {
                try
                {
                    UserInfor = dal.GetUserInfor(userName, userPwd);
                    if (UserInfor != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, UserInfor, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)UserInfor;
        }


        /// <summary>
        /// 获取[权限用户]信息
        /// </summary>
        public DataTable GetUserInfor(int userID, string userName, string userPwd, int userPurview)
        {
            return dal.GetUserInfor(userName, userPwd, userPurview);
        }

        /// <summary>
        /// 从缓存中获取[权限用户]信息
        /// </summary>
        public DataTable GetUserInforByCache(int userID, string userName, string userPwd, int userPurview)
        {
            string CacheKey = "znUserInfor-" + userID;
            object UserInfor = znCache.GetCache(CacheKey);
            if (UserInfor == null)
            {
                try
                {
                    UserInfor = dal.GetUserInfor(userName, userPwd, userPurview);
                    if (UserInfor != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, UserInfor, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)UserInfor;
        }

        /// <summary>
        /// 获取登录用户[一级模块]
        /// </summary>
        public DataTable GetUserModule(int userID, string userName, int userPurview, int layerID)
        {
            return dal.GetUserModule(userName, userPurview, layerID);
        }

        /// <summary>
        /// 从缓存中获取登录用户[一级模块]
        /// </summary>
        public DataTable GetUserModuleByCache(int userID, string userName, int userPurview, int layerID)
        {
            string CacheKey = "znModule-" + userID;
            object Module = znCache.GetCache(CacheKey);
            if (Module == null)
            {
                try
                {
                    Module = dal.GetUserModule(userName, userPurview, layerID);
                    if (Module != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, Module, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)Module;
        }

        /// <summary>
        /// 获取登录用户指定子模块
        /// </summary>
        public DataTable GetUserModuleList(int userID, string userName, int userPurview, int parentID)
        {
            return dal.GetUserModuleList(userName, userPurview, parentID);
        }

        /// <summary>
        /// 从缓存中获取登录用户指定子模块
        /// </summary>
        public DataTable GetUserModuleListByCache(int userID, string userName, int userPurview, int parentID)
        {

            string CacheKey = "znModuleList-" + userID + "-" + parentID; //使用ParentID标识不同模块的缓存
            object ModuleList = znCache.GetCache(CacheKey);
            if (ModuleList == null)
            {
                try
                {
                    ModuleList = dal.GetUserModuleList(userName, userPurview, parentID);
                    if (ModuleList != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, ModuleList, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)ModuleList;
        }

    }
}
