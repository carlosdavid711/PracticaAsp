using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Terceintento.Models
{
    public class Asignaciones
    {
        public int ID { get; set; }
        public string CursoID { get; set; }
        public int EstudiantesID { get; set; }
        public int MaestroID { get; set; }



        public virtual Estudiantes Estudiante { set; get; }
        public virtual Maestros Maestro { set; get; }
        public virtual Cursos Curso { set; get; }

    }
}