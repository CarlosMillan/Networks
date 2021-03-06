﻿using Networks.Controllers;
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
        private List<MSeccion> Sections;

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
            else
                Sections = (List<MSeccion>)ViewState["Sections"];
        }

        private void ReloadIntegrantsTable()
        {
            ReloadIntegrantsTable(C.GetLideresTable());
        }

        private void ReloadIntegrantsTable(List<MLider> filtered)
        {
            DgridLid.DataSource = filtered;
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

        private void ReloadTerritorial()
        {
            DpTerr.DataSource = C.GetTerrotoriales();
            DpTerr.DataTextField = "NombreCompleto";
            DpTerr.DataValueField = "ID";
            this.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (DpSeccion.SelectedItem != null)
            {
                MLider NewLider = new MLider(Int32.Parse(DpTerr.SelectedItem.Value), TxtLastName.Text, TxtMiddleName.Text, TxtNames.Text, Int32.Parse(DpSeccion.SelectedItem.Value)
                                                            , TxtStret.Text, TxtColony.Text, TxtEmail.Text, TxtPhoneHome.Text, TxtPhoneOffice.Text, TxtPhoneNextel.Text, TxtElector.Text);
                Saved = C.SaveLider(NewLider);
                ReloadIntegrantsTable();
                ReloadTerritorial();
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

            if (!String.IsNullOrEmpty(TxtNames.Text))
            {
                CriteriosList.Add(IntegrantsColumns.Nombres);
                CriteriosList.Add(Extensions.SParam(TxtNames.Text));
            }

            if (!String.IsNullOrEmpty(TxtMiddleName.Text))
            {
                CriteriosList.Add(IntegrantsColumns.Materno);
                CriteriosList.Add(Extensions.SParam(TxtMiddleName.Text));
            }

            if (!String.IsNullOrEmpty(TxtElector.Text))
            {
                CriteriosList.Add(IntegrantsColumns.ClaveElector);
                CriteriosList.Add(Extensions.SParam(TxtElector.Text));
            }

            ReloadIntegrantsTable(C.SearchLider(CriteriosList.ToArray()));
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