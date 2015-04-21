using Networks.Controllers;
using Networks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Networks
{
    public partial class Distritos : System.Web.UI.Page
    {
        private CDistritos C;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CDistritos();
            Saved = null;

            if (!IsPostBack)            
                ReloadDistricts();            
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtName.Text))
                {
                    MDistrito New = new MDistrito(TxtName.Text);
                    Saved = C.SaveDistrict(New);
                    ResetGUI();
                }
            }catch{}
        }

        private void ReloadDistricts()
        {
            DgridDistritos.DataSource = C.GetDistricts();
            this.DataBind();
        }

        private void ResetGUI()
        {
            TxtName.Text = string.Empty;
            ReloadDistricts();
        }
    }
}