using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public int ClienteId { get; set; }

        public Clientes Cliente { get; set; }

        public int VentaId { get; set; }

        public Ventas Venta { get; set; }

        public decimal TotalCobrado { get; set; }

        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();

        public Cobros()
        {
            Fecha = DateTime.Now;
        }

    }
}
