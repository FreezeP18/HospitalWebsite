using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteMedico.Models
{
    public class Medico
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string FechaNacimiento { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}