using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregaParcialUno.Entidades;
using System.Data.Entity;

namespace EntregaParcialUno.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<productos> Producto { get; set; }
        public DbSet<ValorInventario> ValorInventarioC { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
