﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diego_P2_AP2.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }

        [ForeignKey("ClienteId")]
        public virtual List<Ventas> Venta { get; set; }

        [ForeignKey("ClienteId")]
        public virtual List<Cobros> Cobro { get; set; }
    }
}
