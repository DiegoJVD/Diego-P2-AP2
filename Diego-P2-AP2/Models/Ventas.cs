using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }

        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
    }
}
