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
    public partial class VistaMedicamentos : System.Web.UI.Page
    {
        private const string RutaXmlMedicamentos = "~/Databases/Medicamentos.xml";

        private void Page_Load(object sender, EventArgs e)
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
                    CargarMedicamentos();

                }
            }
        }


        private void CargarMedicamentos()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicamentos);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            // Limpiar contenido existente
            tablaMedicamentos.InnerHtml = "";

            var medicamentoModel = xmlDoc.Descendants("Medicamento")
             .Select(m => new Medicamentos
             {
                 MedicamentoId = (string)m.Element("MedicamentoId") ?? "",
                 NombreMed = (string)m.Element("NombreMed") ?? "",
                 Presentacion = (string)m.Element("Presentacion") ?? "",
                 Concentracion = (string)m.Element("Concentracion") ?? "",
                 CodigoMS = (string)m.Element("CodigoMS") ?? "",
                 CasaFarmaceutica = (string)m.Element("CasaFarmaceutica") ?? "",
             });


            foreach (var medicamento in medicamentoModel)
            {
                string row = $@"
                    <tr>
                        <td>{medicamento.MedicamentoId}</td>
                        <td>{medicamento.NombreMed}</td>
                        <td>{medicamento.Presentacion}</td>
                        <td>{medicamento.Concentracion}</td>
						<td>{medicamento.CodigoMS}</td>
						<td>{medicamento.CasaFarmaceutica}</td>

                    </tr>";

                tablaMedicamentos.InnerHtml += row;
            }
        }

        protected void GuardarMedicamento(object sender, EventArgs e)
        {
            try
            {
                // Recuperar valores del formulario
                var MedicamentoId = txtMedicamentoId.Value;
                var NombreMed = txtNombreMed.Value;
                var Presentacion = txtPresentacion.Value;
                var Concentracion = txtConcentracion.Value;
                var CodigoMS = txtCodigoMS.Value;
                var CasaFarmaceutica = txtCasaFarmaceutica.Value;


                // Validación para no agregar valores no validos
                if (string.IsNullOrEmpty(MedicamentoId) ||
                    string.IsNullOrEmpty(Presentacion) ||
                    string.IsNullOrEmpty(Concentracion) ||
                    string.IsNullOrEmpty(CodigoMS) ||
                    string.IsNullOrEmpty(CasaFarmaceutica))

                {
                    divAlerta.InnerText = "Debe ingresar todos los datos.";
                    divAlerta.Visible = true;
                    return;
                }

                divAlerta.Visible = false;

                // Lógica para guardar en XML
                var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicamentos);
                var xmlDoc = XDocument.Load(rutaXmlCompleta);

                // Crea un elemento XML nuevo
                var nuevoMedicamento = new XElement("Medicamento",
                    new XElement("MedicamentoId", MedicamentoId),
                    new XElement("NombreMed", NombreMed),
                    new XElement("Presentacion", Presentacion),
                    new XElement("Concentracion", Concentracion),
                    new XElement("CodigoMS", CodigoMS),
                    new XElement("CasaFarmaceutica", CasaFarmaceutica)

                );

                xmlDoc.Element("Medicamentos").Add(nuevoMedicamento);

                // Sobre escribe el XML existente
                xmlDoc.Save(rutaXmlCompleta);


                // Recargar la lista de médicos
                CargarMedicamentos();
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