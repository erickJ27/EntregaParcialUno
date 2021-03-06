﻿using System;
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
        public DbSet<Productos> Producto { get; set; }
        public DbSet<ValorInventario> ValorInventario { get; set; }

        public DbSet<Ubicaciones> Ubicaciones { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
