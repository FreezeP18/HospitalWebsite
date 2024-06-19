using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteMedico.Models
{
    public class Enfermedades
    {
        public string EnfermedadId { get; set; }
        public string NombreEnf { get; set; }
        public string Sintomas { get; set; }
        public string CodigoOMS { get; set; }
        public string Paises { get; set; }
        public string Tratamiento { get; set; }
        public string Descubridor { get; set; }

    }
}