using System;
using System.Web.UI;
using ZS.KIT;

public partial class uc_hr_apply : System.Web.UI.UserControl
{
    private int _id = 0;

    /// <summary>
    /// 控件初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this._id = znConvert.ObjToInt(Page.RouteData.Values["id"], 0) | znRequest.GetQueryInt("id");
        if (this._id == 0)
        {
            Response.Redirect("~/tips.aspx?msg=参数不合法，请勿随意提交数据！", true);
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            GetPosition(this._id);
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void GetPosition(int id)
    {
        ZS.BLL.znHR bll = new ZS.BLL.znHR();
        if (bll.Exists(id, true))
        {
            ZS.Model.znHR model = bll.GetModel(id);
            if (model != null)
            {
                this.tbPosition.Text = model.Title;
            }
        }
        else
        {
            Response.Redirect("~/tips.aspx?msg=该记录不存在，请浏览其它内容！", true);
            Response.End();
        }
    }

    /// <summary>
    /// 提交数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userName = tbUserName.Text.Trim();
        string sex = rblSex.SelectedValue;
        string tel = tbTel.Text.Trim();
        string email = tbEmail.Text.Trim();
        string resume = tbResume.Text.Trim();

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(tel) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(resume))
        {
            Response.Redirect("~/tips.aspx?msg=您输入的信息不完整，请返回！", true);
        }

        ZS.BLL.znResume bll = new ZS.BLL.znResume();
        ZS.Model.znResume model = new ZS.Model.znResume();
        model.PositionID = this._id;
        model.Author = znUtils.FilterStr(userName);
        model.Sex = znUtils.FilterStr(sex);
        model.Tel = znUtils.FilterStr(tel);
        model.Email = znUtils.FilterStr(email);
        model.Resume = znUtils.ToTxt(znUtils.FilterStr(resume));
        model.PostTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        model.isCheck = 0;

        if (bll.Add(model))
        {
            znUtils.Alert("提交成功，请勿重复提交！", znRequest.GetUrlReferrer());
        }
        else
        {
            znUtils.Alert("提交失败，请稍后再提交！", znRequest.GetUrlReferrer());
        }
    }
}