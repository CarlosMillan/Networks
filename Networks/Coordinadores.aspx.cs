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
        private List<MSeccion> Sections;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.Coordinador);
            CD = new CDistritos();

            if (!IsPostBack)
            {
                ReloadIntegrants();
                ReloadSections();
            }
            else
                Sections = (List<MSeccion>)ViewState["Sections"];
        }

        private void ReloadIntegrants()
        {
            DgridCoor.DataSource = C.GetCoordindores();
            this.DataBind();
        }

        private void ReloadSections()
        {
            Sections = CD.GetSections();
            ViewState["Sections"] = Sections;
            DpSeccion.DataSource = Sections;            
            DpSeccion.DataTextField = "Nombre";
            DpSeccion.DataValueField = "ID";
            this.DataBind();
            ShowDistrict();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (DpSeccion.SelectedItem != null)
            {
                MCoordinador NewIntegrant = new MCoordinador(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value)
                                                            , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text);
                Saved = C.SaveCoordinador(NewIntegrant);
                ReloadIntegrants();

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