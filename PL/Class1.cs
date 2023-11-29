using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Class1
    {

        // 1.- atributos
        string Nombre { get; } = "Leonardo";
        public int Edad { get; set; }
        public double Altura { get; set; }
        protected string[] Cursos { get; set; }


        // 1.1.- creacion de metodos

        protected static string[] cursosActuales(string[] cursos)
        {
            Class1 objeto = new Class1(cursos);

            return objeto.Cursos;
        }

        public string[] cursosActuales()
        {
            return Cursos;
        }

        public string ObtenerNombre()
        {
            return Nombre;
        }


        // 1.2.- creacion de constructores
        public Class1(int Edad, double Altura, string[] Cursos)
        {
            this.Edad = Edad;
            this.Altura = Altura;
            this.Cursos = Cursos;
        }

        public Class1(int Edad)
        {
            this.Edad = Edad;
        }

        public Class1(double Altura)
        {
            this.Altura = Altura;
        }

        public Class1(string[] Cursos)
        {
            this.Cursos = Cursos;
        }


        
    }
}
