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
    public partial class Coordinadores : System.Web.UI.Page
    {
        private CIntegrantes C;
        private CDistritos CD;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.Coordinador);
            CD = new CDistritos();

            if (!IsPostBack)
            {
                ReloadIntegrants();
                ReloadSections();
            }
        }

        private void ReloadIntegrants()
        {
            DgridCoor.DataSource = C.GetCoordindores();
            this.DataBind();
        }

        private void ReloadSections()
        {
            DpSeccion.DataSource = CD.GetSections();
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MCoordinador NewIntegrant = new MCoordinador(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value));
            Saved = C.SaveCoordinador(NewIntegrant);
            ReloadIntegrants();
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