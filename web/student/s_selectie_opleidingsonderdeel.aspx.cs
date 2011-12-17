using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_student_s_selectie_opleidingsonderdeel : System.Web.UI.Page
{
    private BLLstudent studenten = new BLLstudent();
    int studentid = 1;
    int insertid = 0;
    protected void UploadButton_Click(object sender, EventArgs e)
    {

        String savePath = @"~/files/";
        try
        {


            foreach (RepeaterItem item in rptVrijstellingen.Items)
            {

                FileUpload file = (FileUpload)item.FindControl("FileUpload1");

                if (file.HasFile)
                    {
                       TextBox EVK = (TextBox)item.FindControl("EVK");
                        TextBox SP = (TextBox)item.FindControl("SP");
                        DropDownList dropRapport = (DropDownList)item.FindControl("dropRapport");
                        HiddenField hiddenid = (HiddenField)item.FindControl("hiddenid");
                        
                        String fileName = file.FileName;
                        savePath += fileName;
                        file.SaveAs(Server.MapPath(savePath + fileName));

                        ExternVak ev = new ExternVak();
                        ev.externvakNaam = EVK.Text;
                        ev.externvakStudiepunt = SP.Text;
                        studenten.insertExternvak(ev);
                        insertid = ev.pk_externvakID;

                        Bijlage bij = new Bijlage();
                        System.Threading.Thread.Sleep(3000);
                       
                        bij.fk_externvakID = insertid;
                        bij.pk_bijlageID = Convert.ToInt16(dropRapport.SelectedValue);
                        studenten.update(bij);

                        Bijlage s = new Bijlage();
                        s.bijlageTitel = fileName;
                        s.bijlageURL = savePath;
                        s.bijlageType = "2";
                        s.fk_externvakID = insertid;
                        studenten.insertFile(s);

                        Evk ek = new Evk();
                        ek.fk_vakID = Convert.ToInt16(hiddenid.Value);
                        ek.fk_externvakID = insertid;
                        ek.fk_studentID = studentid;
                        studenten.updateEVK(ek);        
                    }
                    else
                    {
                        throw new Exception("Gelieve bij alle vakken een file toe te voegen of gegeven aan mevrouw Van Orlé aan te vinken en een afspraak te maken.");
                    }
                

            

          
        }
            Response.Redirect("s_upload_bijlagen.aspx");
            
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
           


            List<Evk> lijstVrijstellingen = studenten.selectVrijstellingById(studentid);

            rptVrijstellingen.DataSource = lijstVrijstellingen;
            rptVrijstellingen.DataBind();
            foreach (RepeaterItem item in rptVrijstellingen.Items)
            {
                DropDownList dropRapport = (DropDownList)item.FindControl("dropRapport");
                dropRapport.DataSource = studenten.selectBijlageById(studentid);
                dropRapport.DataValueField = "pk_bijlageID";
                dropRapport.DataTextField = "bijlageTitel";
                dropRapport.DataBind();
            }
        }
        
    }
}
