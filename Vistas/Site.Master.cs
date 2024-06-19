using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpedienteMedico.Models;

namespace ExpedienteMedico
{
    public partial class SiteMaster : MasterPage
    {
        public Boolean SesionActiva = false;
        public String RolUsuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            divFooter.Visible = false;
            Usuario usuario = (Usuario)Session["Usuario"];
            if (usuario != null)
            {
                RolUsuario = usuario.Rol;
                divFooter.Visible = true;
            }
        }
    }
}