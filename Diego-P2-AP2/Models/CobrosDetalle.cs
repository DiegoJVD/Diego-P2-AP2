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
        public int Id { get; set; }

        public Cobros Cobro { get; set; }

        public Ventas Venta { get; set; }

        public int VentaId { get; set; }

        public decimal Cobrado { get; set; }

    }
}
