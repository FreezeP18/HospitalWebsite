using ExpedienteMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ExpedienteMedico.Globals;
using Newtonsoft.Json.Linq;

namespace ExpedienteMedico
{
    public partial class VistaCitas : System.Web.UI.Page
    {
        private const string RutaXmlCitas = "~/Databases/Citas.xml";
        private const string RutaXmlMedicos = "~/Databases/Medicos.xml";
        private const string RutaXmlPacientes = "~/Databases/Pacientes.xml";
        private const string RutaXmlEnfermedades = "~/Databases/Enfermedades.xml";
        private const string RutaXmlMedicamentos = "~/Databases/Medicamentos.xml";

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
                    OcultarTodosLosElementos();
                    CargarPacientes();
                    CargarMedicamentos();
                    CargarEnfermedades();
                    CargarMedicos();
                    CargarCitas();
                }
                else
                {
                    CargarPacientes();
                    CargarMedicamentos();
                    CargarEnfermedades();
                    CargarMedicos();
                    CargarCitas();
                }
            }
        }

        private void CargarPacientes()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlPacientes);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var pacientes = xmlDoc.Descendants("Paciente")
              .Select(p => new
              {
                  ID = p.Element("Identificacion")?.Value,
                  Nombre = p.Element("Nombre")?.Value,
                  Apellidos = p.Element("Apellidos")?.Value,
                  Genero = p.Element("Genero")?.Value

              });

            foreach (var paciente in pacientes)
            {
                ListItem listItem = new ListItem($"{paciente.ID} - {paciente.Nombre} - {paciente.Apellidos}", paciente.ID + "-" + paciente.Nombre + "-" + paciente.Apellidos + "-" +
                    paciente.Genero);
                ddlPacientes.Items.Add(listItem);
            }
        }

        private void CargarMedicamentos()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicamentos);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var medicamentos = xmlDoc.Descendants("Medicamento")
            .Select(m => new
            {
                MedicamentoId = m.Element("MedicamentoId")?.Value,
                NombreMed = m.Element("NombreMed")?.Value,
                CodigoMS = m.Element("CodigoMS")?.Value

            });

            foreach (var medicamento in medicamentos)
            {
                ListItem listItem = new ListItem(medicamento.NombreMed, medicamento.MedicamentoId + "-" + medicamento.NombreMed + "-" + medicamento.CodigoMS);
                ddlMedicamentoRecetado.Items.Add(listItem);
            }
        }

        private void CargarEnfermedades()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlEnfermedades);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var enfermedades = xmlDoc.Descendants("Enfermedad")
            .Select(e => new
            {
                NombreEnf = e.Element("NombreEnf")?.Value,
                Sintomas = e.Element("Sintomas")?.Value
            });

            foreach (var enfermedad in enfermedades)
            {
                ListItem listItem = new ListItem(enfermedad.NombreEnf, enfermedad.NombreEnf + "-" + enfermedad.Sintomas);
                ddlEnfermedades.Items.Add(listItem);
            }
        }

        private void CargarMedicos()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlMedicos);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            var medicos = xmlDoc.Descendants("Medico")
           .Select(m => new
           {
               Nombre = m.Element("Nombre")?.Value,
               Apellidos = m.Element("Apellidos")?.Value,
               Especialidad = m.Element("Especialidad")?.Value
           });

            foreach (var medico in medicos)
            {
                ListItem listItem = new ListItem($"{medico.Nombre} {medico.Apellidos} - {medico.Especialidad}", medico.Nombre + "-" + medico.Apellidos + "-" + medico.Especialidad);
                ddlMedico.Items.Add(listItem);
            }
        }

        private void CargarCitas()
        {
            var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlCitas);
            var xmlDoc = XDocument.Load(rutaXmlCompleta);

            // Limpiar contenido existente
            tablaCitas.InnerHtml = "";

            var citasModel = xmlDoc.Descendants("Cita")
                .Select(c => new
                {
                    PacienteId = (string)c.Element("Paciente").Element("Id") ?? "",
                    PacienteNombre = (string)c.Element("Paciente").Element("Nombre") ?? "",
                    PacienteApellidos = (string)c.Element("Paciente").Element("Apellidos") ?? "",
                    MedicoNombre = (string)c.Element("Medico").Element("Nombre") ?? "",
                    MedicoApellidos = (string)c.Element("Medico").Element("Apellidos") ?? "",
                    MedicoEspecialidad = (string)c.Element("Medico").Element("Especialidad") ?? "",
                    EnfermedadNombre = (string)c.Element("Enfermedad").Element("Nombre") ?? "",
                    EnfermedadSintomas = (string)c.Element("Enfermedad").Element("Sintomas") ?? "",
                    MedicamentoId = (string)c.Element("MedicamentoRecetado").Element("ID") ?? "",
                    MedicamentoNombre = (string)c.Element("MedicamentoRecetado").Element("Nombre") ?? "",
                    MedicamentoCodigo = (string)c.Element("MedicamentoRecetado").Element("Codigo") ?? "",
                    Fecha = (string)c.Element("Fecha") ?? "",
                    Hora = (string)c.Element("Hora") ?? ""
                });

            foreach (var cita in citasModel)
            {
                string row = $@"
                <tr>
                    <td>{cita.PacienteId}</td>
                    <td>{cita.PacienteNombre}</td>
                    <td>{cita.PacienteApellidos}</td>
                    <td>{cita.MedicoNombre}</td>
                    <td>{cita.MedicoApellidos}</td>
                    <td>{cita.MedicoEspecialidad}</td>
                    <td>{cita.EnfermedadNombre}</td>
                    <td>{cita.EnfermedadSintomas}</td>
                    <td>{cita.MedicamentoNombre}</td>
                    <td>{cita.MedicamentoCodigo}</td>
                    <td>{cita.Fecha}</td>
                    <td>{cita.Hora}</td>
                    </tr>";

                tablaCitas.InnerHtml += row;
            }
        }


        protected void GuardarCita(object sender, EventArgs e)
        {
            try
            {
                var pacienteId = "";
                var pacienteNombre = "";
                var pacienteApellidos = "";
                var medicoApellidos = "";
                var medicoEspecialidad = "";
                var medicoNombre = "";
                var medicamentoID = "";
                var medicamentoNombre = "";
                var medicamentoCodigo = "";
                var enfermedadNombre = "";
                var enfermedadSintomas = "";


                if (!string.IsNullOrEmpty(ddlPacientes.Value))
                {
                    var pacienteSplit = ddlPacientes.Value.Split('-');
                    if (pacienteSplit.Length >= 3)
                    {
                        pacienteId = pacienteSplit[0].Trim();
                        pacienteNombre = pacienteSplit[1].Trim();
                        pacienteApellidos = pacienteSplit[2].Trim();
                    }
                }


                if (!string.IsNullOrEmpty(ddlMedico.Value))
                {
                    var medicoSplit = ddlMedico.Value.Split('-');
                    if (medicoSplit.Length >= 3)
                    {
                        medicoNombre = medicoSplit[0].Trim();
                        medicoApellidos = medicoSplit[1].Trim();
                        medicoEspecialidad = medicoSplit[2].Trim();
                    }
                }


                if (!string.IsNullOrEmpty(ddlMedicamentoRecetado.Value))
                {
                    var medicamentoSplit = ddlMedicamentoRecetado.Value.Split('-');
                    if (medicamentoSplit.Length >= 3)
                    {
                        medicamentoID = medicamentoSplit[0].Trim();
                        medicamentoNombre = medicamentoSplit[1].Trim();
                        medicamentoCodigo = medicamentoSplit[2].Trim();
                    }
                }


                if (!string.IsNullOrEmpty(ddlEnfermedades.Value))
                {
                    var enfermedadSplit = ddlEnfermedades.Value.Split('-');
                    if (enfermedadSplit.Length >= 2)
                    {
                        enfermedadNombre = enfermedadSplit[0].Trim();
                        enfermedadSintomas = enfermedadSplit[1].Trim();
                    }
                }

                var fecha = txtFechaDiagnostico.Value;
                var hora = DateTime.Now.ToString("HH:mm:ss");


                if (string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(hora))
                {
                    divAlerta.InnerText = "Debe ingresar todos los datos.";
                    divAlerta.Visible = true;
                    return;
                }

                divAlerta.Visible = false;

                // Lógica para guardar en XML
                var rutaXmlCompleta = HttpContext.Current.Server.MapPath(RutaXmlCitas);
                var xmlDoc = XDocument.Load(rutaXmlCompleta);

                // Crea un elemento XML nuevo
                var nuevaCita = new XElement("Cita",
                    new XElement("Paciente",
                        new XElement("Id", pacienteId),
                        new XElement("Nombre", pacienteNombre),
                        new XElement("Apellidos", pacienteApellidos)
                    ),
                    new XElement("Medico",
                        new XElement("Nombre", medicoNombre),
                        new XElement("Apellidos", medicoApellidos),
                        new XElement("Especialidad", medicoEspecialidad)
                    ),
                    new XElement("Enfermedad",
                        new XElement("Nombre", enfermedadNombre),
                        new XElement("Sintomas", enfermedadSintomas)
                    ),
                    new XElement("MedicamentoRecetado",
                        new XElement("ID", medicamentoID),
                        new XElement("Nombre", medicamentoNombre),
                        new XElement("Codigo", medicamentoCodigo)

                    ),
                    new XElement("Fecha", fecha),
                    // La hora se coloca al final
                    new XElement("Hora", hora)
                );


                xmlDoc.Element("Citas").Add(nuevaCita);

                // Sobre escribe el XML existente
                xmlDoc.Save(rutaXmlCompleta);

                // Recargar la lista de citas médicas si es necesario
                CargarCitas();

                // Mostrar mensaje de éxito
                divAlerta.InnerText = "Cita guardada correctamente.";
                divAlerta.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                divAlerta.InnerText = "Error al guardar la cita: " + ex.Message;
                divAlerta.Visible = true;
            }

            finally
            {

            }
        }

        private void OcultarTodosLosElementos()
        {
            menuCitas.Visible = menuEnfermedades.Visible = menuMedicamentos.Visible =
                menuMedicos.Visible = menuPacientes.Visible = false;

       
        }


    }



}
