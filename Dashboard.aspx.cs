using System;
using ExpedienteMedico.Models;
using ExpedienteMedico.Globals;
using System.Web.UI;

namespace ExpedienteMedico
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                OcultarTodosLosElementos();
                if (usuario.Rol == Roles.Paciente.ToString()) {
                    Response.Redirect("~/VerCitasPaciente.aspx");
                } else if (usuario.Rol == Roles.Medico.ToString()) {
                    MostrarElementosMedico();
                } else {
                    MostrarElementosAdmin();
                }
            }
        }

        private void OcultarTodosLosElementos()
        {
            menuCitas.Visible = menuEnfermedades.Visible = menuMedicamentos.Visible =
                menuMedicos.Visible = menuPacientes.Visible = false;

            cardCitas.Visible = cardEnfermedades.Visible = cardMedicamentos.Visible =
                cardMedicos.Visible = cardPacientes.Visible = false;
        }

        private void MostrarElementosAdmin()
        {
            menuCitas.Visible = menuEnfermedades.Visible = menuMedicamentos.Visible =
                menuMedicos.Visible = menuPacientes.Visible = true;

            cardCitas.Visible = cardEnfermedades.Visible = cardMedicamentos.Visible =
                cardMedicos.Visible = cardPacientes.Visible = true;
        }

        private void MostrarElementosMedico()
        {
            menuCitas.Visible = cardCitas.Visible = true;
            menuPacientes.Visible = cardPacientes.Visible = false;
        }

    }
}
