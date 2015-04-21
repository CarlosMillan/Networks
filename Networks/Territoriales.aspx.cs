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
    public partial class Territoriales : System.Web.UI.Page
    {
        private CIntegrantes C;
        private CDistritos CD;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.Territorial);
            CD = new CDistritos();
            Saved = null;

            if (!IsPostBack)
            {
                ReloadIntegrantsTable();
                ReloadSections();
                ReloadCoordinadores();
            }
        }

        private void ReloadIntegrantsTable()
        {
            DgridTerr.DataSource = C.GetTerrotoriales();
            this.DataBind();
        }

        private void ReloadSections()
        {
            DpSeccion.DataSource = CD.GetSections();
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
        }

        private void ReloadCoordinadores()
        {
            DpCoor.DataSource = C.GetCoordindores();
            DpCoor.DataTextField = "Nombres";
            DpCoor.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MTerritorial NewTerritorial = new MTerritorial(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value), Int32.Parse(DpCoor.SelectedItem.Value));
            Saved = C.SaveTerritorial(NewTerritorial);
            ReloadIntegrantsTable();
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