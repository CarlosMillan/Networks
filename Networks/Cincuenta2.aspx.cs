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
    public partial class Cincuenta2 : System.Web.UI.Page
    {
        private CIntegrantes C;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CIntegrantes(CIntegrantes.TypeIntegrante.L2_50);

            if (!IsPostBack)
                ReloadIntegrantsTable();
        }

        private void ReloadIntegrantsTable()
        {
            ReloadIntegrantsTable(C.Get50_2());
        }

        private void ReloadIntegrantsTable(List<MIntegrante> filtered)
        {
            Dgrid50_2.DataSource = filtered;
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            MIntegrante NewIntegrant = new MIntegrante(TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text
                                                        , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text);
            Saved = C.Save50_2(NewIntegrant);
            ReloadIntegrantsTable();

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

            ReloadIntegrantsTable(C.Search50_2(CriteriosList.ToArray()));
        }
    }
}