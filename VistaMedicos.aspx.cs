using System.Web.UI;
using System;
using System.Linq;
using System.Web;
using ExpedienteMedico.Models;
using System.Xml.Linq;
using ExpedienteMedico.Globals;
using System.Web.UI.WebControls;

namespace ExpedienteMedico
{
    public partial class VistaMedicos : System.Web.UI.Page
    {
        private const string RutaXmlMedicos = "~/Databases/Medicos.xml";
        private const string RutaXmlEspecialidades = "~/Databases/Especialidades.xml";
        private const string RutaXmlEstadosCiviles = "~/Databases/EstadoCivil.xml";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            divAlerta.Visible = false;
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (usuario.Rol == Roles.Paciente.ToString())
                {
                    Response.Redirect("~/VerCitasPaciente.aspx");
                }
                else if (usuario.Rol == Roles.Medico.ToString())
                {
                    Response.Redirect("~/VerCitasPaciente.aspx");
                }
                else
                {
                    CargarMedicos();
                    CargarEspecialidades();
                    CargarEstadosCiviles();
                }
            }
        }

        private void CargarEspecialidades()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlEspecialidades);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var especialidadModel = xmlDoc.Descendants("Especialidad")
                .Select(m => new Especialidad
                {
                    ID = Convert.ToInt32(m.Element("ID").Value),
                    Nombre = m.Element("Nombre").Value,
                });

            foreach (var especialidad in especialidadModel)
            {
                ListItem listItem = new ListItem(especialidad.Nombre, especialidad.Nombre);
                ddlEspecialidad.Items.Add(listItem);
            }
        }


        private void CargarEstadosCiviles()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlEstadosCiviles);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var estadoCivilModel = xmlDoc.Descendants("EstadoCivil")
                .Select(m => new EstadoCivil
                {
                    ID = Convert.ToInt32(m.Element("ID").Value),
                    Nombre = m.Element("Nombre").Value,
                });

            foreach (var estadoCivil in estadoCivilModel)
            {
                ListItem listItem = new ListItem(estadoCivil.Nombre, estadoCivil.Nombre);
                ddlEstadoCivil.Items.Add(listItem);
            }
        }

        private void CargarMedicos()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicos);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            // Limpiar contenido existente
            tablaMedicos.InnerHtml = "";

            var medicosModel = xmlDoc.Descendants("Medico")
             .Select(m => new Medico
                {
                 Identificacion = (string)m.Element("Identificacion") ?? "",
                 TipoIdentificacion = (string)m.Element("TipoIdentificacion") ?? "",
                 Nombre = (string)m.Element("Nombre") ?? "",
                 Apellidos = (string)m.Element("Apellidos") ?? "",
                 Genero = (string)m.Element("Genero") ?? "",
                 EstadoCivil = (string)m.Element("EstadoCivil") ?? "",
                 FechaNacimiento = (string)m.Element("FechaNacimiento") ?? "",
                 Especialidad = (string)m.Element("Especialidad") ?? "",
                 Telefono = (string)m.Element("Telefono") ?? "",
                 Correo = (string)m.Element("Correo") ?? ""
                });


            foreach (var medico in medicosModel)
            {
                string row = $@"
                    <tr>
                        <td>{medico.Identificacion}</td>
                        <td>{medico.TipoIdentificacion}</td>
                        <td>{medico.Nombre}</td>
                        <td>{medico.Apellidos}</td>
                        <td>{medico.Genero}</td>
                        <td>{medico.EstadoCivil}</td>
                        <td>{medico.FechaNacimiento}</td>
                        <td>{medico.Especialidad}</td>
                        <td>{medico.Telefono}</td>
                        <td>{medico.Correo}</td>
                    </tr>";

                tablaMedicos.InnerHtml += row;
            }
        }

        protected void GuardarMedico(object sender, EventArgs e)
        {
            try
            {
                // Recuperar valores del formulario
                var identificacion = txtIdentificacion.Value;
                var tipoIdentificacion = ddlTipoIdentificacion.Value;
                var nombre = txtNombre.Value;
                var apellidos = txtApellidos.Value;
                var genero = ddlGenero.Value;
                var estadoCivil = ddlEstadoCivil.Value;
                var fechaNacimiento = txtFechaNacimiento.Value;
                var especialidad = ddlEspecialidad.Value;
                var telefono = txtTelefono.Value;
                var correo = txtCorreo.Value;

                // Validación para no agregar valores no validos
                if (!Utils.CadenaValida(identificacion) ||
                    !Utils.CadenaValida(nombre) ||
                    !Utils.CadenaValida(apellidos) ||
                    !Utils.CumpleConEdadMinima(fechaNacimiento) ||
                    !Utils.CadenaValida(telefono) ||
                    !Utils.ValidarCorreo(correo))
                {
                    divAlerta.InnerText = "Debe ingresar todos los datos.";
                    divAlerta.Visible = true;
                    return;
                }

                divAlerta.Visible = false;

                // Lógica para guardar en XML
                var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicos);
                var xmlDoc = XDocument.Load(rutaXmlCompleta);

                // Crea un elemento XML nuevo
                var nuevoMedico = new XElement("Medico",
                    new XElement("Identificacion", identificacion),
                    new XElement("TipoIdentificacion", tipoIdentificacion),
                    new XElement("Nombre", nombre),
                    new XElement("Apellidos", apellidos),
                    new XElement("Genero", genero),
                    new XElement("EstadoCivil", estadoCivil),
                    new XElement("FechaNacimiento", fechaNacimiento),
                    new XElement("Especialidad", especialidad),
                    new XElement("Telefono", telefono),
                    new XElement("Correo", correo)
                );

                xmlDoc.Element("Medicos").Add(nuevoMedico);

                // Sobre escribe el XML existente
                xmlDoc.Save(rutaXmlCompleta);


                // Recargar la lista de médicos
                CargarMedicos();
                // Limpiar el formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                divAlerta.InnerText = ex.Message;
                divAlerta.Visible = true;
            }
        }

        private void LimpiarFormulario() {
            txtNombre.Value = "";
            txtApellidos.Value = "";
            txtIdentificacion.Value = "";
            txtTelefono.Value = "";
            txtFechaNacimiento.Value = "";
            txtCorreo.Value = "";
            ddlEspecialidad.SelectedIndex = 0;
            ddlEstadoCivil.SelectedIndex = 0;
            ddlGenero.SelectedIndex = 0;
            ddlTipoIdentificacion.SelectedIndex = 0;
        }
    }
}