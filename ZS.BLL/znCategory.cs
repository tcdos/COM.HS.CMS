using System.Data;

namespace ZS.BLL
{
    public partial class znCategory
    {
        private readonly ZS.DAL.znCategory dal = new ZS.DAL.znCategory();
        public znCategory()
		{}

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
        /// 获取默认类别
        /// </summary>
        public int GetDefaultID(int channelID, int layer)
        {
            return dal.GetDefaultID(channelID, layer);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZS.Model.znCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(ZS.Model.znCategory model)
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
        public ZS.Model.znCategory GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获取数据列表
		/// </summary>
        public DataTable GetList(int parentID, int channelID)
        {
            return dal.GetList(parentID, channelID);
        }

        

    }
}
