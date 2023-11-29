using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Informacion Informacion { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
