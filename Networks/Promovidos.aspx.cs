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
    public partial class Promovidos : System.Web.UI.Page
    {
        private CIntegrantes C;
        private CDistritos CD;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.Promovido);
            CD = new CDistritos();
            Saved = null;

            if (!IsPostBack)
            {
                ReloadIntegrantsTable();
                ReloadSections();
                ReloadLider();
            }
        }

        private void ReloadIntegrantsTable()
        {
            DgridProm.DataSource = C.GetPromovidos();
            this.DataBind();
        }

        private void ReloadSections()
        {
            DpSeccion.DataSource = CD.GetSections();
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
        }

        private void ReloadLider()
        {
            DpLid.DataSource = C.GetLideres();
            DpLid.DataTextField = "Nombres";
            DpLid.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MPromovido NewProm = new MPromovido(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value), Int32.Parse(DpLid.SelectedItem.Value));
            Saved = C.SavePromovido(NewProm);
            ReloadIntegrantsTable();
            ReloadLider();
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