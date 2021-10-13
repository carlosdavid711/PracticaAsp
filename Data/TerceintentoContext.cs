using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Terceintento.Data
{
    public class TerceintentoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TerceintentoContext() : base("name=TerceintentoContext")
        {
        }

        public System.Data.Entity.DbSet<Terceintento.Models.Estudiantes> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<Terceintento.Models.Maestros> Maestros { get; set; }

        public System.Data.Entity.DbSet<Terceintento.Models.Cursos> Cursos { get; set; }

        public System.Data.Entity.DbSet<Terceintento.Models.Asignaciones> Asignaciones { get; set; }
    }
}
