using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteMedico.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rol { get; set; }
        public string UsuarioNombre { get; set; }

        public string Estado { get; set; }
    }

}