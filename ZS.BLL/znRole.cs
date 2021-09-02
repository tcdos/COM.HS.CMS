using System;
using System.Data;
using System.Collections.Generic;
using ZS.KIT;

namespace ZS.BLL
{
    /// <summary>
    /// znRole
    /// </summary>
    public partial class znRole
    {
        private readonly ZS.DAL.znRole dal = new ZS.DAL.znRole();
        public znRole()
        { }

        /// <summary>
        /// 检测角色名称是否存在
        /// </summary>
        public bool Exists(string roleName)
        {
            return dal.Exists(roleName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        public string GetName(int ID)
        {
            return dal.GetName(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znRole model)
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
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znRole GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取一个对象实体，从缓存中
        /// </summary>
        public ZS.Model.znRole GetModelByCache(int ID)
        {

            string CacheKey = "znRoleModel-" + ID;
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
            return (ZS.Model.znRole)objModel;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znRole> DataTableToList(DataTable dt)
        {
            List<ZS.Model.znRole> modelList = new List<ZS.Model.znRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZS.Model.znRole model;
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

    }
}

