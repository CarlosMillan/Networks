using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Networks
{
    public partial class Tipo : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["T"]))
                Response.Redirect("Default.aspx");            
        }

        protected void BtnIntegrants_Click(object sender, EventArgs e)
        {
            Response.Redirect("Integrantes.aspx");
        }

        protected void BtnDistricts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Distritos.aspx");
        }
    }
}