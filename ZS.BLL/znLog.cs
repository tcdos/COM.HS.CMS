using System;
using System.Collections.Generic;
using System.Data;

namespace ZS.BLL
{
    public partial class znLog
    {
        private readonly ZS.DAL.znLog dal = new ZS.DAL.znLog();
        public znLog()
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
        public bool Add(ZS.Model.znLog model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Log"></param>
        /// <returns></returns>
        public bool Add(string UserName, string Log)
        {
            Model.znLog model = new Model.znLog();
            model.UserName = UserName;
            model.LoginIP = ZS.KIT.znRequest.GetIP();
            model.LoginTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
            model.Log = Log;
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znLog model)
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        public ZS.Model.znLog GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<ZS.Model.znLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znLog> DataTableToList(DataTable dt)
        {
            List<ZS.Model.znLog> modelList = new List<ZS.Model.znLog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZS.Model.znLog model;
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
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.znLog GetModel(string UserName)
        {
            return dal.GetModel(UserName);
        }
    }
}
