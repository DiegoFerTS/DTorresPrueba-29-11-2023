using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Informacion LibroAdd(ML.Libro libro)
        {
            ML.Informacion informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "LibrosAdd";

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                    parameters[0].Value = libro.Nombre;
                    parameters[1] = new SqlParameter("@Autor", System.Data.SqlDbType.VarChar);
                    parameters[1].Value = libro.Autor;
                    parameters[2] = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                    parameters[2].Value = libro.Cantidad;
                    parameters[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.Date);
                    parameters[3].Value = libro.FechaPublicacion;

                    command.Parameters.AddRange(parameters);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        informacion.Estatus = true;
                        informacion.Mensaje = "Se registro el libro " + libro.Nombre + " con exito.";
                    } else
                    {
                        informacion.Estatus = false;
                        informacion.Mensaje = "No se registro el libro.";
                    }
                }
            }
            catch (Exception ex)
            {
                informacion.Estatus = false;;
                informacion.Mensaje = ex.Message;
            }

            return informacion;
        }

        public static ML.Informacion LibroUpdate(ML.Libro libro)
        {
            ML.Informacion informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "LibrosUpdate";

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    parameters[0].Value = libro.Id;
                    parameters[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                    parameters[1].Value = libro.Nombre;
                    parameters[2] = new SqlParameter("@Autor", System.Data.SqlDbType.VarChar);
                    parameters[2].Value = libro.Autor;
                    parameters[3] = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                    parameters[3].Value = libro.Cantidad;
                    parameters[4] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.Date);
                    parameters[4].Value = libro.FechaPublicacion;

                    command.Parameters.AddRange(parameters);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        informacion.Estatus = true;
                        informacion.Mensaje = "Se actualizo el libro " + libro.Nombre + " con exito.";
                    }
                    else
                    {
                        informacion.Estatus = false;
                        informacion.Mensaje = "No se actualizo el libro.";
                    }
                }
            }
            catch (Exception ex)
            {
                informacion.Estatus = false; ;
                informacion.Mensaje = ex.Message;
            }

            return informacion;
        }

        public static ML.Informacion LibroDelete(int idLibro)
        {
            ML.Informacion informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "LibrosDelete";

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idLibro;

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        informacion.Estatus = true;
                        informacion.Mensaje = "Se elimino el libro con id: " + idLibro + " con exito.";
                    }
                    else
                    {
                        informacion.Estatus = false;
                        informacion.Mensaje = "No se elimino el libro.";
                    }
                }
            }
            catch (Exception ex)
            {
                informacion.Estatus = false; ;
                informacion.Mensaje = ex.Message;
            }

            return informacion;
        }

        public static ML.Libro LibroGetAll()
        {

            ML.Libro libro = new ML.Libro();
            libro.Libros = new List<ML.Libro>();
            libro.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "LibrosGetAll";

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tablaLibro = new DataTable();

                    adapter.Fill(tablaLibro);

                    if (tablaLibro.Rows.Count > 0)
                    {
                        foreach (DataRow row in tablaLibro.Rows)
                        {
                            ML.Libro libroResult = new ML.Libro();

                            libroResult.Id = int.Parse(row[0].ToString());
                            libroResult.Nombre = row[1].ToString();
                            libroResult.Autor = row[2].ToString();
                            libroResult.Cantidad = int.Parse(row[3].ToString());
                            libroResult.FechaPublicacion = DateTime.ParseExact(row[4].ToString().Split(' ')[0].Replace("/","-"), "d-M-yyyy", CultureInfo.InvariantCulture);

                            libro.Libros.Add(libroResult);
                        }

                        libro.Informacion.Estatus = true;
                        libro.Informacion.Mensaje = "Se encotraron " + tablaLibro.Rows.Count + " libros.";
                    }
                    else
                    {
                        libro.Informacion.Estatus = false;
                        libro.Informacion.Mensaje = "No se encontraron libros.";
                    }
                }
            }
            catch (Exception ex)
            {
                libro.Informacion.Estatus = false; ;
                libro.Informacion.Mensaje = ex.Message;
            }

            return libro;
        }

        public static ML.Libro LibroById(int idLibro)
        {

            ML.Libro libro = new ML.Libro();
            libro.Libros = new List<ML.Libro>();
            libro.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "LibrosGetById";

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idLibro;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tablaLibro = new DataTable();

                    adapter.Fill(tablaLibro);

                    if (tablaLibro.Rows.Count > 0)
                    {

                        libro.Id = int.Parse(tablaLibro.Rows[0][0].ToString());
                        libro.Nombre = tablaLibro.Rows[0][1].ToString();
                        libro.Autor = tablaLibro.Rows[0][2].ToString();
                        libro.Cantidad = int.Parse(tablaLibro.Rows[0][3].ToString());
                        libro.FechaPublicacion = DateTime.ParseExact(tablaLibro.Rows[0][4].ToString().Split(' ')[0].Replace("/", "-"), "d-M-yyyy", CultureInfo.InvariantCulture);

                        libro.Informacion.Estatus = true;
                        libro.Informacion.Mensaje = "Se encotraron " + tablaLibro.Rows.Count + " libros.";
                    }
                    else
                    {
                        libro.Informacion.Estatus = false;
                        libro.Informacion.Mensaje = "No se encontraron libros.";
                    }
                }
            }
            catch (Exception ex)
            {
                libro.Informacion.Estatus = false; ;
                libro.Informacion.Mensaje = ex.Message;
            }

            return libro;
        }
    }
}
