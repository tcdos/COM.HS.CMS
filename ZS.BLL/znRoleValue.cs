using System;
using System.Data;
using ZS.KIT;

namespace ZS.BLL
{
    /// <summary>
    /// znRoleValue
    /// </summary>
    public partial class znRoleValue
    {
        private readonly ZS.DAL.znRoleValue dal = new ZS.DAL.znRoleValue();
        public znRoleValue()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znRoleValue model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znRoleValue model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int RoleID)
        {

            return dal.Delete(RoleID);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znRoleValue GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取一个对象实体，从缓存中
        /// </summary>
        public ZS.Model.znRoleValue GetModelByCache(int ID)
        {

            string CacheKey = "znRoleValueModel-" + ID;
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
            return (ZS.Model.znRoleValue)objModel;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public DataSet GetList(int RoleID)
        {
            return dal.GetList(RoleID);
        }
    }
}
