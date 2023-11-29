using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] cursos = new string[5];

            cursos.SetValue("Python", 0);
            cursos.SetValue("C#", 1);
            cursos.SetValue("Java", 2);
            cursos.SetValue("Kotlin", 3);
            cursos.SetValue("VB", 4);

            Class1 objeto = new Class1(27, 1.7, cursos);

            Console.WriteLine("\nTu nombre es:" + objeto.ObtenerNombre());
            Console.WriteLine("\nTu edad es: " + objeto.Edad);
            Console.WriteLine("\nTu altura es: " + objeto.Altura + "\n");

            string[] cursosActuales = objeto.cursosActuales();

            for (int i = 0; i < cursosActuales.Length; i++)
            {
                Console.WriteLine(i + 1 + "°" + " curso: " + cursosActuales[i]);
            }

            Console.ReadKey();
        }
    }
}
