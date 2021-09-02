using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_hr_employ_edit : znManage
{
    private string _labelName = "ZS.CMS.Content.HR.Employ";
    private int _channelID = 4;
    private string _pageUrl = "employ.aspx";
    private string _action = znEnum.Actions.Add.ToString();
    private int _id = 0;
    private int _categoryID;
    private int _curPage;
    private string _property = string.Empty;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._categoryID = znRequest.GetQueryInt("categoryID");
        this._searchWord = znRequest.GetQueryString("searchWord", true);
        this._property = znRequest.GetQueryString("propetry");
        this._curPage = znRequest.GetQueryInt("page", 1);

        this._id = znRequest.GetQueryInt("id");
        string action = znRequest.GetQueryString("action");
        if (action == znEnum.Actions.Edit.ToString())
        {
            this._action = znEnum.Actions.Edit.ToString();
            if (this._id == 0)
            {
                znUtils.Redirect("参数不正确，请勿随意提交数据！");
            }
        }
        if (!Page.IsPostBack)
        {
            FillGategory();
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                FillData(this._id);
            }
            else
            {
                ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
                tbStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                tbEndDate.Text = DateTime.Now.AddDays(180).ToString("yyyy-MM-dd");
                tbSalary.Text = "面议";
                tbPostTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbUserName.Text = Session["UserName"].ToString();
            }
        }
    }

    /// <summary>
    /// 类别控件绑定
    /// </summary>
    protected void FillGategory()
    {
        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        DataTable dt = bll.GetList(0, this._channelID);
        this.ddlCategory.Items.Clear();
        this.ddlCategory.Items.Add(new ListItem("所有类别", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string ID = dr["ID"].ToString();
            int layer = int.Parse(dr["Layer"].ToString());
            string title = dr["Title"].ToString().Trim();

            if (layer == 1)
            {
                this.ddlCategory.Items.Add(new ListItem(title, ID));
            }
            else
            {
                title = "├ " + title;
                title = znUtils.StringOfChar("　", layer - 1) + title;
                this.ddlCategory.Items.Add(new ListItem(title, ID));
            }
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znHR bll = new ZS.BLL.znHR();
        ZS.Model.znHR model = bll.GetModel(ID);
        if (model != null)
        {
            ddlCategory.SelectedValue = model.CategoryID.ToString();
            tbTitle.Text = model.Title;
            tbLimitNum.Text = model.LimitNum.ToString();
            tbAddress.Text = model.Address;
            tbSalary.Text = model.Salary;
            tbEmail.Text = model.Email;
            tbInfor.Text = model.Infor;
            tbRequest.Text = model.Request;
            tbStartDate.Text = model.StartDate;
            tbEndDate.Text = model.EndDate;
            rblIsCheck.SelectedValue = model.isCheck.ToString();
            tbUserName.Text = model.UserName;
            tbPostTime.Text = model.PostTime;
            if (model.isTop == 1)
            {
                cbIsTop.Checked = true;
            }
            if (model.isElite == 1)
            {
                cbIsElite.Checked = true;
            }
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord.ToString(), this._property.ToString(), this._curPage.ToString());
        if (this._action == znEnum.Actions.Edit.ToString())
        {
            ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
            if (!DoEdit(this._id))
            {
                znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
                return;
            }
            znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
        }
        else
        {
            ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
            if (!DoAdd())
            {
                znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
                return;
            }
            znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
        }
    }


    /// <summary>
    /// 编辑
    /// </summary>
    private bool DoEdit(int ID)
    {
        bool result = false;
        ZS.BLL.znHR bll = new ZS.BLL.znHR();
        if (bll.Exists(ID, false))
        {
            ZS.Model.znHR model = bll.GetModel(ID);
            model.CategoryID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
            model.Title = tbTitle.Text.Trim();
            model.LimitNum = Convert.ToInt32(tbLimitNum.Text.Trim());
            model.Address = tbAddress.Text.Trim();
            model.Salary = tbSalary.Text.Trim();
            model.Email = tbEmail.Text.Trim();
            model.Infor = tbInfor.Text.Trim();
            model.Request = tbRequest.Text.Trim();
            model.StartDate = tbStartDate.Text.Trim();
            model.EndDate = tbEndDate.Text.Trim();
            model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);
            if (cbIsTop.Checked == true)
            {
                model.isTop = 1;
            }
            if (cbIsElite.Checked == true)
            {
                model.isElite = 1;
            }
            model.UserName = string.IsNullOrEmpty(tbUserName.Text.Trim()) ? Session["UserName"].ToString() : tbUserName.Text.Trim();
            model.PostTime = string.IsNullOrEmpty(tbPostTime.Text.Trim()) ? Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") : tbPostTime.Text.Trim();

            if (bll.Update(model))
            {
                result = true;
            }
            return result;
        }
        else
        {
            return result;
        }
    }

    /// <summary>
    /// 新增
    /// </summary>
    private bool DoAdd()
    {
        bool result = false;
        ZS.BLL.znHR bll = new ZS.BLL.znHR();
        ZS.Model.znHR model = new ZS.Model.znHR();

        model.CategoryID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
        model.Title = tbTitle.Text.Trim();
        model.LimitNum = Convert.ToInt32(tbLimitNum.Text.Trim());
        model.Address = tbAddress.Text.Trim();
        model.Salary = tbSalary.Text.Trim();
        model.Email = tbEmail.Text.Trim();
        model.Infor = tbInfor.Text.Trim();
        model.Request = tbRequest.Text.Trim();
        model.StartDate = tbStartDate.Text.Trim();
        model.EndDate = tbEndDate.Text.Trim();
        model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);
        if (cbIsTop.Checked == true)
        {
            model.isTop = 1;
        }
        if (cbIsElite.Checked == true)
        {
            model.isElite = 1;
        }
        model.UserName = string.IsNullOrEmpty(tbUserName.Text.Trim()) ? Session["UserName"].ToString() : tbUserName.Text.Trim();
        model.PostTime = string.IsNullOrEmpty(tbPostTime.Text.Trim()) ? Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") : tbPostTime.Text.Trim();

        if (bll.Add(model))
        {
            result = true;
        }
        return result;
    }

}