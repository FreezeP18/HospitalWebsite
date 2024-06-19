using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteMedico.Models
{
    public class Medicamentos
    {
        public string MedicamentoId { get; set; }
        public string NombreMed { get; set; }
        public string Presentacion { get; set; }
        public string Concentracion { get; set; }
        public string CodigoMS { get; set; }
        public string CasaFarmaceutica { get; set; }

    }
}