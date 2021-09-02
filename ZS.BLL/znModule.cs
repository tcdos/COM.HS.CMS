using System;
using System.Data;
using ZS.KIT;

namespace ZS.BLL
{
    /// <summary>
    /// znModule
    /// </summary>
    public partial class znModule
    {
        private readonly ZS.DAL.znModule dal = new ZS.DAL.znModule();
        public znModule()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 检测模块标签名是否存在
        /// </summary>
        public bool Exists(string labelName)
        {
            return dal.Exists(labelName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znModule model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znModule model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znModule GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取一个对象实体，从缓存中
        /// </summary>
        public ZS.Model.znModule GetModelByCache(int ID)
        {

            string CacheKey = "znModuleModel-" + ID;
            object objModel = znCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZS.Model.znModule)objModel;
        }

        /// <summary>
        /// 获取所有列表[datatree排序]
        /// </summary>
        public DataTable GetList(int parentID)
        {
            return dal.GetList(parentID);
        }

    }
}

