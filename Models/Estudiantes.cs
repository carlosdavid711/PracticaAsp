using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Terceintento.Models
{
    public class Estudiantes
    {
        public int ID { get; set; }
        public int Carnet { get; set; }
        public String PrimerNombre { get; set; }
        public String SegundoNombre { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }
        public String FechaNacimiento { get; set; }
        public int Edad { get; set; }


        public virtual ICollection<Asignaciones> Asignacion { set; get; }
    }
}
