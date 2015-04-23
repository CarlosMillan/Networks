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
    public partial class Doce : System.Web.UI.Page
    {
        private CIntegrantes C;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.L12);

            if (!IsPostBack)
                ReloadIntegrants();
        }

        private void ReloadIntegrants()
        {
            Dgrid12.DataSource = C.Get12();            
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MIntegrante NewIntegrant = new MIntegrante(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text
                                                        , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text);
            Saved = C.Save12(NewIntegrant);
            ReloadIntegrants();

            if (Saved == true) Clear();
        }

        private void Clear()
        {
            TxtLastName.Text = string.Empty;
            TxtMiddleName.Text = string.Empty;
            TxtNames.Text = string.Empty;
            TxtStret.Text = string.Empty;
            TxtColony.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtPhoneHome.Text = string.Empty;
            TxtPhoneOffice.Text = string.Empty;
            TxtPhoneNextel.Text = string.Empty;
        }
    }
}