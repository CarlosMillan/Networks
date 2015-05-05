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
        private List<MSeccion> Sections;

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
            else
                Sections = (List<MSeccion>)ViewState["Sections"];
        }

        private void ReloadIntegrantsTable()
        {
            ReloadIntegrantsTable(C.GetTerrotoriales());
        }

        private void ReloadIntegrantsTable(List<MTerritorial> filtered)
        {
            DgridTerr.DataSource = filtered;            
            this.DataBind();
        }

        private void ReloadSections()
        {
            Sections = CD.GetSections();
            DpSeccion.DataSource = Sections;
            ViewState["Sections"] = Sections;
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
            ShowDistrict();
        }

        private void ReloadCoordinadores()
        {
            DpCoor.DataSource = C.GetCoordindores();
            DpCoor.DataTextField = "NombreCompleto";
            DpCoor.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (DpSeccion.SelectedItem != null)
            {
                MTerritorial NewTerritorial = new MTerritorial(Int32.Parse(DpCoor.SelectedItem.Value), TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value)
                                                            , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text, TxtElector.Text);
                Saved = C.SaveTerritorial(NewTerritorial);
                ReloadIntegrantsTable();

                if (Saved == true) Clear();
            }
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
            TxtElector.Text = string.Empty;
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

            ReloadIntegrantsTable(C.SearchTerritorial(CriteriosList.ToArray()));
        }

        protected void DpSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDistrict();
        }

        private void ShowDistrict()
        {
            try
            {
                LblDistrict.Text = Sections.Find(x => x.Id == Int32.Parse(DpSeccion.SelectedItem.Value)).Distrito;
            }
            catch (Exception E)
            {
                LblDistrict.Text = "SIN DISTRITO";
            }
        }
    }
}