using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.Models
{
    public class CobrosDetalle
    {
        public int id { get; set; }

        public int CobroId { get; set; }

        public Cobros Cobro { get; set; }

        public decimal Cobrado { get; set; }

        public int VentaId { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();

    }
}
