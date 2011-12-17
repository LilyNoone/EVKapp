using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_student_s_student_Ovrijstellingen : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        int studentid = 1; //session
        BLLstudent studenten = new BLLstudent();

        List<Evk> lijstVrijstellingen = studenten.selectVrijstellingById(studentid);
      
        rptVrijstellingen.DataSource = lijstVrijstellingen;
        rptVrijstellingen.DataBind();

    }
}