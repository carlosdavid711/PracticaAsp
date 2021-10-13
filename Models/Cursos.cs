using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Terceintento.Models
{
    public class Cursos
    {
        public int ID { get; set; }
        public String NombreCurso { get; set; }
        public String Descripcion { get; set; }

        public virtual ICollection<Asignaciones> Asignacion { set; get; }
    }
}