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
    public partial class Lideres : System.Web.UI.Page
    {
        private CIntegrantes C;
        private CDistritos CD;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.Lider);
            CD = new CDistritos();
            Saved = null;

            if (!IsPostBack)
            {
                ReloadIntegrantsTable();
                ReloadSections();
                ReloadTerritorial();
            }
        }

        private void ReloadIntegrantsTable()
        {
            DgridLid.DataSource = C.GetLideres();
            this.DataBind();
        }

        private void ReloadSections()
        {
            DpSeccion.DataSource = CD.GetSections();
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
        }

        private void ReloadTerritorial()
        {
            DpTerr.DataSource = C.GetTerrotoriales();
            DpTerr.DataTextField = "Nombres";
            DpTerr.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MLider NewLider = new MLider(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value), Int32.Parse(DpTerr.SelectedItem.Value));
            Saved = C.SaveLider(NewLider);
            ReloadIntegrantsTable();
            ReloadTerritorial();
            Clear();
        }

        private void Clear()
        {
            TxtLastName.Text = string.Empty;
            TxtMiddleName.Text = string.Empty;
            TxtNames.Text = string.Empty;
        }
    }
}