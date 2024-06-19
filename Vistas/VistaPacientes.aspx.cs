using ExpedienteMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpedienteMedico.Globals;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace ExpedienteMedico
{
    public partial class VistaPacientes : System.Web.UI.Page
    {
        private const string RutaXmlPacientes = "~/Databases/Pacientes.xml";
        private const string RutaXmlEspecialidades = "~/Databases/Especialidades.xml";
        private const string RutaXmlEstadosCiviles = "~/Databases/EstadoCivil.xml";
       
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarPacientes();
            CargarEstadosCiviles();
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

        private void CargarPacientes()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlPacientes);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            // Limpiar contenido existente
            tablaPacientes.InnerHtml = "";

            var pacientesModel = xmlDoc.Descendants("Paciente")
             .Select(p => new Paciente
             {
                 Nombre = (string)p.Element("Nombre") ?? "",
                 Apellidos = (string)p.Element("Apellidos") ?? "",
                 Identificacion = (string)p.Element("Identificacion") ?? "",
                 TipoIdentificacion = (string)p.Element("TipoIdentificacion") ?? "",
                
                 Genero = (string)p.Element("Genero") ?? "",
                 EstadoCivil = (string)p.Element("EstadoCivil") ?? "",
                 Nacionalidad = (string)p.Element("Nacionalidad") ?? "",
                 FechaNacimiento = (string)p.Element("FechaNacimiento") ?? "",
                 LugarResidencia = (string)p.Element("LugarResidencia") ?? "",
                 Telefono = (string)p.Element("Telefono") ?? "",
                 Correo = (string)p.Element("Correo") ?? ""
             });


            foreach (var paciente in pacientesModel)
            {
                string row = $@"
                    <tr>
                        <td>{paciente.Nombre}</td>
                        <td>{paciente.Apellidos}</td>
                        <td>{paciente.Identificacion}</td>
                        <td>{paciente.TipoIdentificacion}</td>                      
                        <td>{paciente.Genero}</td>
                        <td>{paciente.EstadoCivil}</td>
                         <td>{paciente.Nacionalidad}</td>
                        <td>{paciente.FechaNacimiento}</td>
                        <td>{paciente.LugarResidencia}</td>
                        <td>{paciente.Telefono}</td>
                        <td>{paciente.Correo}</td>
                    </tr>";

                tablaPacientes.InnerHtml += row;
            }
        }


        protected void GuardarPaciente(object sender, EventArgs e)
        {
            try
            {
                // Recuperar valores del formulario
                var nombre = txtNombre.Value;
                var apellidos = txtApellidos.Value;
                var identificacion = txtIdentificacion.Value;
                var tipoIdentificacion = ddlTipoIdentificacion.Value;
                var genero = ddlGenero.Value;
                var estadoCivil = ddlEstadoCivil.Value;
                var nacionalidad = txtNacionalidad.Value;
                var fechaNacimiento = txtFechaNacimiento.Value;
                var lugarResidencia = txtLugarResidencia.Value;
                var telefono = txtTelefono.Value;
                var correo = txtCorreo.Value;

                // Validación para no agregar valores no validos
                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(apellidos) ||
                    string.IsNullOrEmpty(identificacion) ||
                    string.IsNullOrEmpty(genero) ||
                    string.IsNullOrEmpty(estadoCivil) ||
                    string.IsNullOrEmpty(nacionalidad) ||
                    string.IsNullOrEmpty(fechaNacimiento) ||
                    string.IsNullOrEmpty(lugarResidencia) ||
                    string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(correo))

                {
                    divAlerta.InnerText = "Debe ingresar todos los datos.";
                    divAlerta.Visible = true;
                    return;
                }

                divAlerta.Visible = false;

                // Lógica para guardar en XML
                var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlPacientes);
                var xmlDoc = XDocument.Load(rutaXmlCompleta);

                // Crea un elemento XML nuevo
                var nuevoPaciente = new XElement("Paciente",
                    new XElement("Nombre", nombre),
                    new XElement("Apellidos", apellidos),
                    new XElement("Identificacion", identificacion),
                    new XElement("TipoIdentificacion", tipoIdentificacion),
                   
                    new XElement("Genero", genero),
                    new XElement("EstadoCivil", estadoCivil),
                    new XElement("Nacionalidad", nacionalidad),
                    new XElement("FechaNacimiento", fechaNacimiento),
                    new XElement("LugarResidencia", lugarResidencia),
                    new XElement("Telefono", telefono),
                    new XElement("Correo", correo)
                );

                xmlDoc.Element("Pacientes").Add(nuevoPaciente);

                // Sobre escribe el XML existente
                xmlDoc.Save(rutaXmlCompleta);


                // Recargar la lista de médicos
                CargarPacientes();
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                divAlerta.InnerText = ex.Message;
                divAlerta.Visible = true;
            }
        }
    }
}