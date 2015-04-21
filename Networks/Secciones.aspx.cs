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
    public partial class Secciones : System.Web.UI.Page
    {
        private CDistritos C;
        public bool? Saved;

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new CDistritos();
            Saved = null;

            if (!IsPostBack)
            {
                ReloadSections();
                ReloadDistricts();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtName.Text))
            {
                MDistrito SelectedDistrict = new MDistrito(Int32.Parse(DpDistritos.SelectedItem.Value), DpDistritos.SelectedItem.Text);
                MSeccion NewSeccion = new MSeccion(SelectedDistrict, TxtName.Text);
                Saved = C.SaveSection(NewSeccion);
                ReloadSections();
                TxtName.Text = string.Empty;
            }
        }

        private void ReloadDistricts()
        {
            DpDistritos.DataSource = C.GetDistricts();
            DpDistritos.DataTextField = "Nombre";
            DpDistritos.DataValueField = "ID";
            this.DataBind();            
        }

        private void ReloadSections()
        {
            DgridSecciones.DataSource = C.GetSections();
            this.DataBind();
        }
    }
}