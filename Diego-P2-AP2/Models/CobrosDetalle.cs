using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int id { get; set; }

        public Cobros cobro { get; set; }

        public Ventas venta { get; set; }

        public int ventaId { get; set; }

        public decimal Cobrado { get; set; }

    }
}
