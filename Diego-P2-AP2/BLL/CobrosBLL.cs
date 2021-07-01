using Diego_P2_AP2.DAL;
using Diego_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.BLL
{
    public class CobrosBLL
    {

        public static bool Guardar(Cobros cobros)
        {
            if (!Existe(cobros.CobroId))
                return Insertar(cobros);
            else
                return Modificar(cobros);
        }
        private static bool Insertar(Cobros cobros)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Cobros.Add(cobros);
                found = context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Modificar(Cobros cobros)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Entry(cobros).State = EntityState.Modified;
                found = context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                var cobros = context.Cobros.Find(id);

                if (cobros != null)
                {
                    context.Cobros.Remove(cobros);
                    found = context.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }

        public static Cobros Buscar(int id)
        {
            Contexto context = new Contexto();
            Cobros cobros =new Cobros();

            try
            {
                cobros = context.Cobros
                   .Include(x => x.Detalle)
                   .ThenInclude(x => x.venta)
                   .Include(x => x.CobroId == id)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return cobros;
        }
        public static bool Existe(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                found = context.Cobros.Any(p => p.CobroId == id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }

        public static List<Cobros> GetList()
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto context = new Contexto();
            try
            {
                lista = context.Cobros
                   .Include(x => x.Detalle)
                   .ThenInclude(x => x.venta)
                   .Include(x => x.CobroId == id)
                   .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
            return lista;
        }

    }
}
