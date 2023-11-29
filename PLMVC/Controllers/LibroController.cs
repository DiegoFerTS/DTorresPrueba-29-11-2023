using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Informacion = new ML.Informacion();

            libro = BL.Libro.LibroGetAll();

            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? idLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Informacion = new ML.Informacion();

            if(idLibro != 0 && idLibro != null)
            {
                libro = BL.Libro.LibroById(idLibro.Value);
            }

            return View(libro);
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Libro libroResult = new ML.Libro();
            libroResult.Informacion = new ML.Informacion();

            if (libro.Id == 0 || libro.Id == null)
            {
                libroResult.Informacion = BL.Libro.LibroAdd(libro);
            } else
            {
                libroResult.Informacion = BL.Libro.LibroUpdate(libro);
            }

            return View(libroResult);
        }

        [HttpGet]
        public ActionResult Delete(int idLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Informacion = new ML.Informacion();

            if (idLibro != 0 && idLibro != null)
            {
                libro.Informacion = BL.Libro.LibroDelete(idLibro);
            }

            return View("GetAll");
        }

    }
}