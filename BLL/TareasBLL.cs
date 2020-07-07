using _2doParcial.DAL;
using _2doParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2doParcial.BLL
{
    public class TareasBLL
    {
        public static bool Guardar(Tareas tarea)
        {
            if (!Existe(tarea.TareaId))
                return Insertar(tarea);
            else
                return Modificar(tarea);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Tareas.Any(p => p.TareaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Tareas.Add(tarea);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        private static bool Modificar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(tarea).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Tareas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tareas tareas;

            try
            {
                tareas = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tareas;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var tarea = contexto.Tareas.Find(id);
                contexto.Entry(tarea).State = EntityState.Deleted;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static List<Tareas> GetTareas()
        {
            List<Tareas> lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Tareas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
