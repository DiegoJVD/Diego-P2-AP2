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
                foreach (var item in cobros.Detalle)
                {
                    item.Venta = context.Ventas.Find(item.VentaId);
                    item.Venta.Balance = item.Venta.Balance - item.Cobrado;
                    context.Entry(item.Venta).State = EntityState.Modified;
                }
                  //  context.Entry(item).State = EntityState.Added;
                context.Cobros.Add(cobros);
                found = (context.SaveChanges() > 0);
               


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
                foreach (var item in cobros.Detalle)
                    context.Entry(item).State = EntityState.Modified;
                context.Cobros.Add(cobros);
                found = (context.SaveChanges() > 0);

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
                    foreach (var item in cobros.Detalle)
                        context.Entry(item).State = EntityState.Deleted;
                    context.Cobros.Remove(cobros);
                    found = (context.SaveChanges() > 0);
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
                   .ThenInclude(x => x.Venta)
                   .Where(x => x.CobroId == id)
                    .FirstOrDefault();

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
                   .Include(x => x.Cliente)
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

        public static List<CobrosDetalle> ObtenerDetalle(int id)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();
            List<CobrosDetalle> detalle = new List<CobrosDetalle>();
            try
            {
                lista = contexto.Ventas
                    .Include(x => x.Cliente)
                    .Where(v => v.ClienteId == id && v.Balance > 0)
                    .ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            } 

            foreach (var item in lista)
            {
                detalle.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0
                });
            }
                return detalle;
            

        }

    }
}
