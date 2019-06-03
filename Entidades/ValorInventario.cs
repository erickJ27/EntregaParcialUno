using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntregaParcialUno.Entidades
{
    public class ValorInventario
    {
        [Key]
        public int id { get; set; }  
        public decimal ValorTotalInventario { get; set; }

        ValorInventario()
        {
            id = 0;
            ValorTotalInventario = 0;
        }
    }
}
