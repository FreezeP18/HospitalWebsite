using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteMedico.Globals
{
    public class Utils
    {
        // Método para validar un correo electrónico
        public static bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                var esValida = addr.Address == correo;
                return esValida;
            }
            catch
            {
                return false;
            }
        }

        // Método para validar una cadena
        public static bool CadenaValida(string cadena)
        {
            var esValida = !string.IsNullOrEmpty(cadena);
            return esValida;
        }

        // Método para validar la edad mínima
        public static bool CumpleConEdadMinima(string fechaNacimiento)
        {
            DateTime fechaNac, fechaActual;
            if (DateTime.TryParse(fechaNacimiento, out fechaNac))
            {
                fechaActual = DateTime.Today;
                if (fechaActual.Year - fechaNac.Year > 18)
                {
                    return true;
                }
                else if (fechaActual.Year - fechaNac.Year == 18)
                {
                    if (fechaActual.Month > fechaNac.Month)
                    {
                        return true;
                    }
                    else if (fechaActual.Month == fechaNac.Month)
                    {
                        if (fechaActual.Day >= fechaNac.Day)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
