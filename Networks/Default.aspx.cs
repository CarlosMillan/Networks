using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Networks
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnRegestry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tipo.aspx?T=Regestry");
        }

        protected void BtnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tipo.aspx?T=Query");
        }
    }
}