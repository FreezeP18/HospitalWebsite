using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpedienteMedico.Models;
using System.Web.Services;
using System.Xml.Linq;
using System.Web.Http;
using ExpedienteMedico.Globals;

namespace ExpedienteMedico
{
    public partial class _Default : Page
    {
        private const string RutaXmlUsuarios = "~/Databases/Usuarios.xml";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            divAlerta.Visible = false;
        }

        protected void IniciarSesion(object sender, EventArgs e) {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                divAlerta.Visible = true;
                return;
            }

            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlUsuarios);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var usuarioEncontrado = xmlDoc.Descendants("Usuario")
                .FirstOrDefault(u => (string)u.Element("Usuario") == usuario && (string)u.Element("Password") == password && (string)u.Element("Estado") == "Activo");

            if (usuarioEncontrado != null)
            {
                var usuarioAutenticado = new Usuario
                {
                    UsuarioID = (int)usuarioEncontrado.Element("UsuarioID"),
                    Nombre = (string)usuarioEncontrado.Element("Nombre"),
                    Apellidos = (string)usuarioEncontrado.Element("Apellidos"),
                    Identificacion = (string)usuarioEncontrado.Element("Identificacion"),
                    TipoIdentificacion = (string)usuarioEncontrado.Element("TipoIdentificacion"),
                    Genero = (string)usuarioEncontrado.Element("Genero"),
                    EstadoCivil = (string)usuarioEncontrado.Element("EstadoCivil"),
                    FechaNacimiento = (DateTime)usuarioEncontrado.Element("FechaNacimiento"),
                    Rol = (string)usuarioEncontrado.Element("Rol"),
                    UsuarioNombre = (string)usuarioEncontrado.Element("Usuario"),
                };

                HttpContext.Current.Session["Usuario"] = usuarioAutenticado;
                var rolUsuario = usuarioAutenticado.Rol;
                if (rolUsuario == Roles.Paciente.ToString())
                {
                    Response.Redirect("~/VerCitasPaciente.aspx");
                }
                else {
                    Response.Redirect("~/Dashboard.aspx");
                }

            }
            else {
                divAlerta.Visible = true;
            }
            
        }

    }
}