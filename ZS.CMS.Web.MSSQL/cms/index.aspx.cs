using System;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_index : znManage
{
    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow dr = GetUserInfor().Rows[0];
        this.Page.Title = znTech.clientName;
        this.litUser.Text = GetUserPannel(znConvert.ObjToInt(dr["ID"], 0), dr["UserName"].ToString());
        this.litUserModule.Text = GetMoudule(znConvert.ObjToInt(dr["ID"], 0), dr["UserName"].ToString(), znConvert.ObjToInt(dr["Purview"], 0));
        this.litUserModuleList.Text = GetModuleList(znConvert.ObjToInt(dr["ID"], 0), dr["UserName"].ToString(), znConvert.ObjToInt(dr["Purview"], 0));
    }

}