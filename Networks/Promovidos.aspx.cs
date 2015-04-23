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
            ReloadIntegrantsTable(C.GetPromovidos());
        }

        private void ReloadIntegrantsTable(List<MPromovido> filtered)
        {
            DgridProm.DataSource = filtered;
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
            DpLid.DataTextField = "NombreCompleto";
            DpLid.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MPromovido NewProm = new MPromovido(Int32.Parse(DpLid.SelectedItem.Value), TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value)
                                                        , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text);
            Saved = C.SavePromovido(NewProm);
            ReloadIntegrantsTable();
            ReloadLider();
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            List<object> CriteriosList = new List<object>();

            if (!String.IsNullOrEmpty(TxtLastName.Text))
            {
                CriteriosList.Add(IntegrantsColumns.Paterno);
                CriteriosList.Add(Extensions.SParam(TxtLastName.Text));
            }

            if (!String.IsNullOrEmpty(TxtMiddleName.Text))
            {
                CriteriosList.Add(IntegrantsColumns.Materno);
                CriteriosList.Add(Extensions.SParam(TxtMiddleName.Text));
            }

            if (!String.IsNullOrEmpty(TxtNames.Text))
            {
                CriteriosList.Add(IntegrantsColumns.Nombres);
                CriteriosList.Add(Extensions.SParam(TxtNames.Text));
            }

            ReloadIntegrantsTable(C.SearchPromovido(CriteriosList.ToArray()));
        }
    }
}