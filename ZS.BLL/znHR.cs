using System.Collections.Generic;
using System.Data;

namespace ZS.BLL
{
    public partial class znHR
    {
        private readonly ZS.DAL.znHR dal = new ZS.DAL.znHR();
        public znHR()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, bool isCheck)
        {
            return dal.Exists(ID, isCheck);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 获取默认ID
        /// </summary>
        public int GetDefaultID()
        {
            return dal.GetDefaultID();
        }

        /// <summary>
        /// 获取类别
        /// </summary>
        public int GetCategoryID(int id)
        {
            return dal.GetCategoryID(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znHR model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znHR model)
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
        public ZS.Model.znHR GetModel(int ID)
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
        public DataSet GetList(int categoryID, string strWhere, string filedOrder)
        {
            return dal.GetList(categoryID, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znHR> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znHR> DataTableToList(DataTable dt)
        {
            List<ZS.Model.znHR> modelList = new List<ZS.Model.znHR>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZS.Model.znHR model;
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
        public DataSet GetList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            return dal.GetList(categoryID, pageSize, pageIndex, strWhere, sortFiled, out recordCount);
        }

    }
}
