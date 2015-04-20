using Networks.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Networks
{
    public partial class Secciones : System.Web.UI.Page
    {
        private CDistritos C;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CDistritos();
            
            if (!IsPostBack)
                ReloadDistricts();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void ReloadDistricts()
        {
            DpDistritos.DataSource = C.GetDistricts();
            DpDistritos.DataTextField = "Name";
            DpDistritos.DataValueField = "Id";
            this.DataBind();
        }
    }
}