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

        public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public int CobroId { get; set; }

        public decimal Balance { get; set; }

        public decimal Cobrado { get; set; }

        public bool Pago { get; set; }

    }
}
