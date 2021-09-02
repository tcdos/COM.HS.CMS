using System.Collections.Generic;
using System.Data;

namespace ZS.BLL
{
    public partial class znCase
    {
        private readonly ZS.DAL.znCase dal = new ZS.DAL.znCase();
        public znCase()
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
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znCase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZS.Model.znCase model)
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
        public ZS.Model.znCase GetModel(int ID)
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
        public List<ZS.Model.znCase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ZS.Model.znCase> DataTableToList(DataTable dt)
        {
            List<ZS.Model.znCase> modelList = new List<ZS.Model.znCase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZS.Model.znCase model;
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
        /// 获取前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取数据列表[分页]
        /// </summary>
        public DataSet GetList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            return dal.GetList(categoryID, pageSize, pageIndex, strWhere, sortFiled, out recordCount);
        }

        /// <summary>
        /// 获取数据列表[指定页数]
        /// </summary>
        public DataSet GetPageList(int categoryID, int pageSize, int pageIndex, string strWhere, string sortFiled, out int recordCount)
        {
            return dal.GetPageList(categoryID, pageSize, pageIndex, strWhere, sortFiled, out recordCount);
        }
    }
}
