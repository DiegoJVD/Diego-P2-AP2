using Diego_P2_AP2.DAL;
using Diego_P2_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.BLL
{
    public class ClientesBLL
    {
        public static List<Clientes> GetList()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes.ToList();
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

        public static Clientes Buscar(int id)
        {
            Contexto context = new Contexto();
            Clientes cliente;

            try
            {
                cliente = context.Clientes.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return cliente;
        }
    }
}
