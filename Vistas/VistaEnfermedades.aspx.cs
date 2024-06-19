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
    public partial class VistaEnfermedades : System.Web.UI.Page
    {
        private const string RutaXmlEnfermedades = "~/Databases/Enfermedades.xml";


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
                    CargarEnfermedades();

                }
            }
        }


        private void CargarEnfermedades()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlEnfermedades);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            // Limpiar contenido existente
            tablaEnfermedades.InnerHtml = "";

            var enfermedadModel = xmlDoc.Descendants("Enfermedad")
             .Select(m => new Enfermedades
             {
                 EnfermedadId = (string)m.Element("EnfermedadId") ?? "",
                 NombreEnf = (string)m.Element("NombreEnf") ?? "",
                 Sintomas = (string)m.Element("Sintomas") ?? "",
                 CodigoOMS = (string)m.Element("CodigoOMS") ?? "",
                 Paises = (string)m.Element("Paises") ?? "",
                 Tratamiento = (string)m.Element("Tratamiento") ?? "",
                 Descubridor = (string)m.Element("Descubridor") ?? "",
             });


            foreach (var enfermedad in enfermedadModel)
            {
                string row = $@"
                    <tr>
                        <td>{enfermedad.EnfermedadId}</td>
                        <td>{enfermedad.NombreEnf}</td>
                        <td>{enfermedad.Sintomas}</td>
                        <td>{enfermedad.CodigoOMS}</td>
						<td>{enfermedad.Paises}</td>
						<td>{enfermedad.Tratamiento}</td>
						<td>{enfermedad.Descubridor}</td>

                    </tr>";

                tablaEnfermedades.InnerHtml += row;
            }
        }

        protected void GuardarEnfermedad(object sender, EventArgs e)
        {
            try
            {
                // Recuperar valores del formulario
                var EnfermedadId = txtEnfermedadId.Value;
                var NombreEnf = txtNombreEnf.Value;
                var Sintomas = txtSintomas.Value;
                var CodigoOMS = txtCodigoOMS.Value;
                var Paises = txtPaises.Value;
                var Tratamiento = txtTratamiento.Value;
                var Descubridor = txtDescubridor.Value;


                // Validación para no agregar valores no validos
                if (string.IsNullOrEmpty(EnfermedadId) ||
                    string.IsNullOrEmpty(NombreEnf) ||
                    string.IsNullOrEmpty(Sintomas) ||
                    string.IsNullOrEmpty(CodigoOMS) ||
                    string.IsNullOrEmpty(Paises) ||
                    string.IsNullOrEmpty(Descubridor) ||
                    string.IsNullOrEmpty(Tratamiento) 
                    )
                {
                    divAlerta.InnerText = "Debe ingresar todos los datos.";
                    divAlerta.Visible = true;
                    return;
                }

                divAlerta.Visible = false;

                // Lógica para guardar en XML
                var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlEnfermedades);
                var xmlDoc = XDocument.Load(rutaXmlCompleta);

                // Crea un elemento XML nuevo
                var nuevaEnfermedad = new XElement("Enfermedad",
                    new XElement("EnfermedadId", EnfermedadId),
                    new XElement("NombreEnf", NombreEnf),
                    new XElement("Sintomas", Sintomas),
                    new XElement("CodigoOMS", CodigoOMS),
                    new XElement("Paises", Paises),
                    new XElement("Tratamiento", Tratamiento),
                    new XElement("Descubridor", Descubridor)
                    

                );

                xmlDoc.Element("Enfermedades").Add(nuevaEnfermedad);

                // Sobre escribe el XML existente
                xmlDoc.Save(rutaXmlCompleta);


                // Recargar la lista de médicos
                CargarEnfermedades();
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