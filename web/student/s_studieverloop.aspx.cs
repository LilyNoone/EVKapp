using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_student_s_studieverloop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<int> data = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                data.Add(i);
            }

            _rptStudieverloop.DataSource = data;
            _rptStudieverloop.DataBind();
        }
    }

    int studentid = 1;
    protected void btnNext_goedkeuring_Click(object sender, EventArgs e)
    {
        String savePath = @"~/files/";

        try
        {
            BLLbijlage BLLbijlage = new BLLbijlage();
            BLLstudent studenten = new BLLstudent();

            foreach (RepeaterItem item in _rptStudieverloop.Items)
            {
                FileUpload _FileUpload = (FileUpload)item.FindControl("_FileUpload");
                DropDownList _dropJaar = (DropDownList)item.FindControl("_dropJaar");
                TextBox _txtSchool = (TextBox)item.FindControl("_txtSchool");
                TextBox _txtOpleiding = (TextBox)item.FindControl("_txtOpleiding");


                    String fileName = _FileUpload.FileName;
                    savePath += fileName;
                    _FileUpload.SaveAs(Server.MapPath(savePath + fileName));

                    Bijlage b = new Bijlage();
                    b.bijlageTitel = fileName;
                    b.bijlageSchoolJaar = _dropJaar.SelectedValue;
                    b.bijlageSchoolGegevens = _txtSchool.Text;
                    b.bijlageSchoolOpleiding = _txtOpleiding.Text;
                    b.bijlageURL = savePath;
                    b.bijlageType = "rapport";
                    b.fk_studentID = studentid;
                    studenten.insertFile(b);
            }
        }
        catch (Exception ex)
        {
            _lblFeedback.Text = ex.Message;
        }
    }
    protected void _rptStudieverloop_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}