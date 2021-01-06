using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class Personas
    {
        public string cedula { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string sexo { get; set; }
        public DateTime F_Nacimiento { get; set; }
        public string correo { get; set; }
        public int estatura { get; set; }
        public Decimal peso { get; set; }
    }
}
