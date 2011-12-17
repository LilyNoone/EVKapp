using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class web_student_s_upload_bijlagen : System.Web.UI.Page
{
    BLLstudent BLLstudent = new BLLstudent();

    protected void UploadButton_Click(object sender, EventArgs e)
    {
            String savePath = @"~/files/";
            try
            {

            
                    foreach (RepeaterItem item in rptVrijstellingen.Items)
                    {

                        FileUpload file = (FileUpload)item.FindControl("FileUpload1");
                        HiddenField uid = (HiddenField)item.FindControl("hiddenid");
                        CheckBox ch = (CheckBox)item.FindControl("CBupload");
                        if (ch.Checked)
                        {
                            Response.Write("checked");
                        }
                        else
                        {

                            if (file.HasFile)
                            {
                                String fileName = file.FileName;
                                savePath += fileName;
                                file.SaveAs(Server.MapPath(savePath + fileName));
                                Bijlage s = new Bijlage();
                                s.bijlageTitel = fileName;
                                s.bijlageURL = savePath;
                                s.bijlageType = "1";
                                s.fk_externvakID = Convert.ToInt16(uid.Value);
                                BLLstudent.insertFile(s);
                            }
                            else
                            {
                                throw new Exception("Gelieve bij alle vakken een file toe te voegen of gegeven aan mevrouw Van Orlé aan te vinken en een afspraak te maken.");
                            }
                        }

                    }
            
                    Response.Redirect("s_student_Ovrijstellingen.aspx");
        }
        
            catch (Exception ex)
            {
                UploadStatusLabel.Text = ex.Message;


            }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int studentid = 1;
            BLLstudent studenten = new BLLstudent();

            List<Evk> lijstVrijstellingen = studenten.selectVrijstellingById(studentid);

            rptVrijstellingen.DataSource = lijstVrijstellingen;
            rptVrijstellingen.DataBind();
        }
    }
}
